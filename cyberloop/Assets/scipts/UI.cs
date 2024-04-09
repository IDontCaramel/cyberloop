using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreUI : MonoBehaviour
{
    public int Score = 0;
    public TextMeshProUGUI guiScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        guiScore.text = Score.ToString();
    }
}
