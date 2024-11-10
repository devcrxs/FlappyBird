using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Experience HUD")]
    [SerializeField] private Slider sliderBarExperience;
    [SerializeField] private TextMeshProUGUI textExperience;
    
    [Header("Timer")]
    private int minutes;
    private int seconds;
    private float timeSpeed;
    [SerializeField] private TextMeshProUGUI timerText;
    
    [Header("Rhythm")]
    [SerializeField] private Slider sliderRhythm;
    
    [Header("DeathScore")]
    [SerializeField] private TextMeshProUGUI textDeathScore;
    
    [Header("LevelUpMenu")]
    [SerializeField] private GameObject levelUpMenu;
    

    public static UIManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        UpdateExperience();
        
    }

    private void Update()
    {
        UpdateTimer();
    }

    public void UpdateExperience()
    {
        sliderBarExperience.value = GameManager.instance.ActualExperience / 100;
        textExperience.text = GameManager.instance.ActualLevel.ToString();
        // TODO : metodo checar nivel
    }
    private void UpdateTimer()
    {
        timeSpeed += Time.deltaTime;
        
        if (timeSpeed >= 1f)
        {
            seconds++;
            timeSpeed = 0;
            if (seconds == 60)
            {
                minutes ++;
                seconds = 0;
            }
        }

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    

    public void UpdateRhythm(float timeShoot)
    {
        sliderRhythm.value = 0;
        sliderRhythm.DOValue(1, timeShoot);
    }

    public void UpdateEnemyDeath()
    {
       textDeathScore.text = GameManager.instance.DeathScore.ToString();
    }
    public void StartLevelUpMenu()
    {
        Time.timeScale = 0f;
        levelUpMenu.SetActive(true);
    }

    public void EndLevelUpMenu()
    {
        Time.timeScale = 1f;
        levelUpMenu.SetActive(false);
        
    }
}
