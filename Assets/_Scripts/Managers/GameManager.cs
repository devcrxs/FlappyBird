using UnityEngine;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float maxExperience = 100f;
    [SerializeField] private float actualExperience;
    [SerializeField] private int actualLevel;
    public static GameManager instance;

    public int ActualLevel => actualLevel;
    public float ActualExperience => actualExperience;
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
    }
}
