using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBarController : MonoBehaviour
{
    public Image xpBar;
    public Text lvlText;

    private void Start()
    {
        xpBar.fillAmount = 0f;
        lvlText.text = "Level: 1";
    }

    private void OnEnable()
    {
        PlayerXpController.OnXpChanged += SetXp;
        PlayerXpController.OnLevelUp += SetLevel;
    }

    private void OnDisable()
    {
        PlayerXpController.OnXpChanged -= SetXp;
        PlayerXpController.OnLevelUp -= SetLevel;
    }

    public void SetXp(OnXpChanged value)
    {
        xpBar.fillAmount = (float)value.currentXp / value.xpTreshold;
    }

    public void SetLevel(OnLevelUp value)
    {
        lvlText.text = "Level: " + value.level.ToString();
    }
}
