using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [Header("Experience HUD")]
    [SerializeField] private Slider sliderBarExperience;
    [SerializeField] private TextMeshProUGUI textExperience;

    public static UIManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        UpdateExperience();
    }

    public void UpdateExperience()
    {
        sliderBarExperience.value = GameManager.instance.ActualExperience / 100;
        textExperience.text = GameManager.instance.ActualLevel.ToString();
        // TODO : metodo checar nivel
    }
}
