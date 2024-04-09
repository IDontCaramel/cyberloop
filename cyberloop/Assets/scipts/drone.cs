using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator anim;
    public LayerMask Ground;
    public Transform GroundCheck;

    private bool CanMove = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        int layerMask1 = 1 << LayerMask.NameToLayer("ground");
        int layerMask2 = 1 << LayerMask.NameToLayer("DroneHelper");

        int combinedLayerMask = layerMask1 | layerMask2;

        RaycastHit2D hitGround = Physics2D.Raycast(GroundCheck.position, Vector2.down, 0.2f, combinedLayerMask);
        Debug.DrawRay(GroundCheck.position, Vector2.down * 0.2f, Color.blue);

        if (!hitGround.collider)
        {
            Flip();
            
        }
    }

    private void FixedUpdate()
    {
        if (CanMove)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }


    void Flip()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
        speed *= -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("BOOM");
            CanMove = false;
            StartCoroutine(Delete(0.6f));
        }
    }
    IEnumerator Delete(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.SetActive(false);
    }
}
