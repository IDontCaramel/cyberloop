using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 direction = Vector2.right;

    private void Start()
    {
        StartCoroutine(sudoku(4.5f));
    }

    void Update()
    {
        // Move the bullet in the set direction
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision + " col");
        Destroy(gameObject);
    }

    IEnumerator sudoku(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Debug.Log("sudoku");
        Destroy(gameObject);
    }
}
