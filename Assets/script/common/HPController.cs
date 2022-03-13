using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HPController : MonoBehaviour
{
    public event Action<OnDamagedEvent> OnDamaged = delegate { };
    public event Action<OnHealedEvent> OnHealed = delegate { };
    public event Action OnKilled = delegate { };

    private float baseDefend = 0f;
    private float currentHp, maxHp;

    public void Heal(float value)
    {
        this.currentHp = ((this.currentHp + value) >= this.maxHp)
            ? this.maxHp
            : (this.currentHp + value);
        OnHealed.Invoke(new OnHealedEvent(value, this.currentHp, this.maxHp));
    }

    public void Damage(float value)
    {
        float damagedValue = value - this.baseDefend;

        Debug.Log("damagedValue: " + damagedValue);

        this.currentHp = ((damagedValue > 0) && (this.currentHp - damagedValue) <= 0)
            ? 0
            : (this.currentHp - damagedValue);
        OnDamaged.Invoke(new OnDamagedEvent(damagedValue, this.currentHp, this.maxHp));

        if (this.currentHp <= 0)
        {
            this.Kill();
        }
    }

    public void SetHp(float value)
    {
        this.currentHp = (value >= this.maxHp)
            ? ((value <= 0)? 0 : this.maxHp)
            : value;
    }

    public void SetMaxHp(float value)
    {
        this.maxHp = value;
        this.currentHp = (this.currentHp >= this.maxHp)
            ? this.maxHp
            : this.currentHp;
    }

    public void SetBaseDefend(float value)
    {
        this.baseDefend = value;
    }

    public void Kill()
    {
        OnKilled.Invoke();
    }

    public float GetCurrentHp() => this.currentHp;
    public float GetMaxHp() => this.maxHp;
}
