using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    public TextMeshProUGUI buttonText; 
    private bool isPaused = false; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // pause game time
        buttonText.text = "Continue"; // change button 
    }

    private void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // continue game time
        buttonText.text = "Pause"; // change button
    }
}
