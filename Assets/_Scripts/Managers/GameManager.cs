using UnityEngine;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float maxExperience = 100f;
    [SerializeField] private float actualExperience;
    [SerializeField] private int actualLevel;
    public static GameManager instance;
    
    [Header("DeathScore")]
    [SerializeField] private int deathScore;

    public int ActualLevel => actualLevel;
    public float ActualExperience => actualExperience;
    public int DeathScore => deathScore;
    
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    
    public void AddExperience(float amount)
    {
        actualExperience += amount;
        if (!(actualExperience >= maxExperience)) return;
        actualExperience = 0;
        actualLevel++;
        UIManager.instance.StartLevelUpMenu();
        
    }

    public void AddScoreDeath()
    {
        deathScore++;
    }
}
