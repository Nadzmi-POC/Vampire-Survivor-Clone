using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public Stat stat;

    private HPController hpController;

    public Stat GetStat() => stat;

    private void Start()
    {
        hpController = GetComponent<HPController>();

        if (stat == null)
        {
            LogHelper.ShowErrorLog(this.name, "Property 'stat' must have a value.");
        }
        if (hpController == null)
        {
            LogHelper.ShowErrorLog(this.name, "Property 'hpController' must have a value.");
        }

        hpController.SetMaxHp(stat.hp);
        hpController.SetHp(stat.hp);
    }

    private void OnEnable()
    {
        hpController.OnKilled += Killed;
    }

    private void OnDisable()
    {
        hpController.OnKilled -= Killed;
    }

    void Killed()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject);
    }
}
