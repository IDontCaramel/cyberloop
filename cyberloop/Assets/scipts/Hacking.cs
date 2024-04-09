using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;
public class Hacking : MonoBehaviour
{
    private GameObject player;
    private Transform target;
    public float visionRange = 10f;

    public float HackSpeed = 0.005f;
    public float progress = 0f;
    public bool isHacked;
    public Transform pBar; // Assuming pBar is the parent object of the progress bar image
    public SpriteRenderer BarCollor;

    private GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindWithTag("GameCanvas");
        if (canvas == null)
        {
            Debug.LogError("Canvas GameObject not found with tag 'GameCanvas'");
        }

        // Find the player and set it as the target
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogError("Player GameObject not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (progress >= 0.99f && !isHacked)
        {
            if (canvas != null)
            {
                ScoreUI scoreUI = canvas.GetComponentInChildren<ScoreUI>();
                if (scoreUI != null)
                {
                    scoreUI.Score++;
                    isHacked = true;
                    BarCollor.color = Color.green;
                    StartCoroutine(Delay(1f));
                }
                else
                {
                    Debug.LogError("ScoreUI component not found on Canvas children!");
                }
            }
        }

        if (player != null && !isHacked)
        {
            Vector2 directionToPlayer = player.transform.position - transform.position;

            if (directionToPlayer.magnitude <= visionRange)
            {
                RaycastHit2D ray = Physics2D.Raycast(transform.position, directionToPlayer, visionRange);

                if (ray.collider != null && ray.collider.gameObject == player)
                {
                    Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
                    progress += HackSpeed;

                    // Limit progress to 1 (complete)
                    progress = Mathf.Clamp(progress, 0f, 1f);

                    // Update the scale of the progress bar
                    pBar.localScale = new Vector3(progress, 1f, 1f);
                }
                else
                {
                    Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
                }
            }

        }
    }

    IEnumerator Delay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        BarCollor.color = new Color(0, 0, 0, 0);
    }
}
