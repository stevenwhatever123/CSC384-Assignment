using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject pauseMenu;

    public GameObject tutorialPanel;

    public void Tab()
    {
        if (IsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        if (TutorialManager.firstTimePlaying)
        {
            tutorialPanel.SetActive(true); 
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        if (TutorialManager.firstTimePlaying)
        {
            tutorialPanel.SetActive(false); 
        }
    }
}
