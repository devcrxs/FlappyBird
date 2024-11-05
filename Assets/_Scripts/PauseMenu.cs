using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject buttonPauseMenu;
    private bool GamePaused;
    

    public void PauseGame()
    {
        GamePaused = true;
        Time.timeScale = 0f;
        buttonPauseMenu.SetActive(false);
        pause.SetActive(true);
    }

    public void ResumeGame()
    {
        GamePaused = false;
        Time.timeScale = 1;
        buttonPauseMenu.SetActive(true);
        pause.SetActive(false);
    }
    
    
}
