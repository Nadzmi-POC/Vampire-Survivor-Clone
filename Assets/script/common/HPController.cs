using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HPController : MonoBehaviour
{
    public event Action<OnDamagedEvent> OnDamaged = delegate { };
    public event Action<OnHealedEvent> OnHealed = delegate { };
    public event Action OnKilled = delegate { };

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
        this.currentHp = ((this.currentHp - value) <= 0)
            ? 0
            : (this.currentHp - value);
        OnDamaged.Invoke(new OnDamagedEvent(value, this.currentHp, this.maxHp));

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

    public void Kill()
    {
        OnKilled.Invoke();
    }

    public float GetCurrentHp() => this.currentHp;
    public float GetMaxHp() => this.maxHp;
}
