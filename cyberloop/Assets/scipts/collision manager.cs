using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sp;
    private Rigidbody2D rb;
    private Collider2D col;
    private Movement SciptMovement;

    public Sprite hurt;

    public GameObject DeahtScreen;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        SciptMovement = GetComponent<Movement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit");
            anim.enabled = false;
            sp.sprite = hurt;
            col.isTrigger = true;
            rb.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            SciptMovement.canJump = false;
            StartCoroutine(screen(2));

        }
    }
    IEnumerator screen(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        DeahtScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    
}

