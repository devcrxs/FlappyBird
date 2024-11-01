using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarraExp : MonoBehaviour
{ 
    
    
    [SerializeField] private Image expBar;
    [SerializeField] private float maxExp = 100f;
    [SerializeField] private float actualExp = 0f;
    [SerializeField] private int lvl = 0;
    [SerializeField] private int initialLevel = 0;
    [SerializeField] private TextMeshProUGUI expText;
    
    void Start()
    {
        lvl = initialLevel; 
    }
    void Update()
    {
        expBar.fillAmount = actualExp / maxExp;
        CheckLevelUp();
        expText.text = lvl.ToString();
    }

    public void SetExp(float amount)
    {
        AddExp(amount); 
    }

    private void AddExp(float amount)
    {
        actualExp += amount;

        if (actualExp >= maxExp)
        {
            actualExp -= maxExp;
            lvl++;
        }
        if (actualExp > maxExp)
        {
            actualExp = maxExp;
        }
        
    }

    private void CheckLevelUp()
    {
        
    }

    public int GetLevel()
    {
        return lvl + 1;
    }
}
