using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public bool isActive = true;
    public WeaponStat stat;

    private void Start()
    {
        if (stat == null)
        {
            LogHelper.ShowErrorLog(this.name, "Property 'stat' must have a value.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActive)
        {
            OnHit(collision);
        }
    }

    public virtual void Activate()
    {
        isActive = true;
    }

    public virtual void Deactivate()
    {
        isActive = false;
    }

    protected abstract void OnHit(Collider2D collision);
}
