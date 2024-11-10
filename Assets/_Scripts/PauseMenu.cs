using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pause;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pause.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }
}
