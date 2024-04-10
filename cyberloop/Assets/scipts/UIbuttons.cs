using UnityEngine;
using UnityEngine.SceneManagement;

public class UIbuttons : MonoBehaviour
{
    public GameObject HelpCanvas;
    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
        ScoreUI.Score = 0;
        Time.timeScale = 1.0f;
    }
    public void MainMenu()
    {
        ScoreUI.Score = 0;
        SceneManager.LoadScene("main menu");
        Time.timeScale = 1.0f;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        ScoreUI.Score = 0;
        SceneManager.LoadScene("level 1");
        Time.timeScale = 1.0f;
    }

    public void HelpScreen()
    {
        if (HelpCanvas.activeSelf)
        {
            HelpCanvas.SetActive(false);
        }
        else
        {
            HelpCanvas.SetActive(true);
        }
    }

}
