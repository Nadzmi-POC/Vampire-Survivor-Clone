using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBarController : MonoBehaviour
{
    public Image xpBar;

    private void OnEnable()
    {
        PlayerXpController.OnXpChanged += SetXp;
    }

    private void OnDisable()
    {
        PlayerXpController.OnXpChanged -= SetXp;
    }

    public void SetXp(OnXpChanged value)
    {
        xpBar.fillAmount = (float) value.currentXp / value.xpTreshold;
    }
}
