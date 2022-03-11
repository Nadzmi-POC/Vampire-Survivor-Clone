using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{
    public HPController hpController;

    private Vector3 hpBar;

    private void Start()
    {
        hpBar = transform.localScale;

        if (hpBar == null)
        {
            LogHelper.ShowErrorLog(this.name, "Property 'hpBar' must have a value.");
        }
        if (hpController == null)
        {
            LogHelper.ShowErrorLog(this.name, "Property 'hpController' must have a value.");
        }
    }

    private void OnEnable()
    {
        hpController.OnDamaged += Damaged;
        hpController.OnHealed += Healed;
    }

    private void OnDisable()
    {
        hpController.OnDamaged -= Damaged;
        hpController.OnHealed -= Healed;
    }

    public void SetHp(float curValue, float maxValue)
    {
        hpBar.x = curValue / maxValue;
        transform.localScale = hpBar;
    }

    void Damaged(OnDamagedEvent eventVal)
    {
        this.SetHp(eventVal.curValue, eventVal.maxValue);
        // TODO: show text animation for damaged based on eventVal.value
        Debug.Log("Damaged: " + eventVal.value);
    }

    void Healed(OnHealedEvent eventVal)
    {
        this.SetHp(eventVal.curValue, eventVal.maxValue);
        // TODO: show text animation for healed based on eventVal.value
        Debug.Log("Healed: " + eventVal.value);
    }
}
