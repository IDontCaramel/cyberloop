using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private GameObject canvas;
    void Start()
    {
        canvas = GameObject.FindWithTag("GameCanvas");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreUI scoreUI = canvas.GetComponentInChildren<ScoreUI>();
        if (ScoreUI.Score >= 10)
        {
            SceneManager.LoadScene("EndScreen");
        }
        else
        {
            scoreUI.Message("you need atleast 10 consoles to finish");
        }
    }
}
