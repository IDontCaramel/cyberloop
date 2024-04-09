using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    public float sprintPower = 1f;
    private bool isFacingRight = true;


    public Animator anim;

    public bool canJump = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool delay = false;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("speed", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump") && IsGrounded() && !delay && canJump)
        {
            anim.SetBool("IsJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            delay = true;
            StartCoroutine(JumpDelay(0.2f));
        }
        else if (IsGrounded() && !delay)
        {
            anim.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("IsSprinting", true);
            speed += sprintPower;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            anim.SetBool("IsSprinting", false);
            speed -= sprintPower;
        }

        Flip();
    }

    IEnumerator JumpDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        delay = false;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    
}
