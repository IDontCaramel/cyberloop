using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public static int Score = 0;
    public TextMeshProUGUI guiScore;
    public TextMeshProUGUI txtMessage;


    private void Update()
    {
        guiScore.text = Score.ToString();
    }

    public void Message(string message)
    {
        txtMessage.text = message;
        StartCoroutine(ClearText(3f));
    }

    IEnumerator ClearText(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        txtMessage.text = "";
    }
}
