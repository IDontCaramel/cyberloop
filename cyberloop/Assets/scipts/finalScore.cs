using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class finalScore : MonoBehaviour
{
    public TextMeshProUGUI UItext;
    public TextMeshProUGUI UItextShadow;

    // Start is called before the first frame update
    void Start()
    {
        if (UItext != null)
        {
            UItext.text = "You obtained " + ScoreUI.Score + "/20 consoles";
            UItextShadow.text = "You obtained " + ScoreUI.Score + "/20 consoles";
        }
        else
        {
            Debug.LogError("UItext is not assigned in the inspector!");
        }
    }
}
