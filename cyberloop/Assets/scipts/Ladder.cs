using UnityEngine;

public class Ladder : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 3f;
    private bool isLadder;
    private bool isClimbing;

    public Animator anim;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0.1f)
        {
            isClimbing = true;
            anim.enabled = true;
        }
        else if (isLadder && Mathf.Abs(vertical) < 0.01f)
        {
            anim.enabled = false;
        }
        else { anim.enabled = true; }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
            anim.SetBool("IsClimbing", true);
        }
        else
        {
            rb.gravityScale = 1f;
            anim.SetBool("IsClimbing", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder"))
        {
            isLadder = true;
            anim.enabled = true; // Enable animations when touching ladder
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder"))
        {
            isLadder = false;
            isClimbing = false;
            anim.enabled = false; // Disable animations when not touching ladder
        }
    }
}
