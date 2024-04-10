using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sp;
    private Rigidbody2D rb;
    private Collider2D col;
    private Movement SciptMovement;
    private Ladder LadderScript;

    public int lives = 0;
    public Sprite hurt;

    public GameObject DeahtScreen;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        SciptMovement = GetComponent<Movement>();
        LadderScript = GetComponent<Ladder>();
    }

    private void Update()
    {
        if (transform.position.y < -7f)
        {
            StartCoroutine(screen(1f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ExtraLife"))
        {
            lives++;
            collision.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("bullet") || collision.gameObject.CompareTag("Spike"))
        {
            LadderScript.disable = true;
            if (LadderScript.isClimbing)
            {
                LadderScript.isClimbing = false;
            }
            Debug.Log("hit");
            if (lives > 0)
            {
                anim.enabled = false;
                sp.sprite = hurt;
                rb.AddForce(Vector2.up * 2f, ForceMode2D.Impulse);
                StartCoroutine(enableAnim(1f));
                lives--;
            }
            else
            {
                anim.enabled = false;
                sp.sprite = hurt;
                col.isTrigger = true;
                rb.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                SciptMovement.canJump = false;
                StartCoroutine(screen(2f));
            }

        }

    }

        

    IEnumerator screen(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        DeahtScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    IEnumerator enableAnim(float delayTime)
    {
        Debug.Log("anim on1");
        yield return new WaitForSeconds(delayTime);
        anim.enabled = true;
        LadderScript.disable = false;
    }

}

