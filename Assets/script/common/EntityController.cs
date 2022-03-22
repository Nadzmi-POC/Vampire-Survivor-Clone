using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    public Stat stat;
    public HPController hpController;
    public EntityType type;

    public Stat GetStat() => stat;

    private void Start()
    {
        if (stat == null)
        {
            LogHelper.ShowErrorLog(this.name, "Property 'stat' must have a value.");
        }
        if (hpController == null)
        {
            LogHelper.ShowErrorLog(this.name, "Property 'hpController' must have a value.");
        }

        this.Initialization();
    }

    private void OnEnable()
    {
        hpController.OnKilled += Killed;
    }

    private void OnDisable()
    {
        hpController.OnKilled -= Killed;
    }

    protected virtual void Initialization()
    {
        hpController.SetMaxHp(stat.hp);
        hpController.SetHp(stat.hp);
        hpController.SetBaseDefend(this.stat.defend);
    }

    protected virtual void Killed()
    {
        Destroy(gameObject);
    }
}
