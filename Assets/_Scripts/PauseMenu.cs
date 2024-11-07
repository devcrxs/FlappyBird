using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject buttonPauseMenu;
    public void PauseGame()
    {
        Time.timeScale = 0f;
        buttonPauseMenu.SetActive(false);
        pause.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        buttonPauseMenu.SetActive(true);
        pause.SetActive(false);
    }
}
