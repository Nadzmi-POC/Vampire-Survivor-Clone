using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EntityController : MonoBehaviour
{
    public static event Action<OnPlayerDied> OnPlayerDied;

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
        GameController.OnPause += PauseEntity;
        GameController.OnResume += ResumeEntity;
    }

    private void OnDisable()
    {
        hpController.OnKilled -= Killed;
        GameController.OnPause -= PauseEntity;
        GameController.OnResume -= ResumeEntity;
    }

    protected virtual void Initialization()
    {
        hpController.SetMaxHp(stat.hp);
        hpController.SetHp(stat.hp);
        hpController.SetBaseDefend(this.stat.defend);
    }

    protected virtual void Killed()
    {
        if(this.type == EntityType.player) {
            OnPlayerDied?.Invoke(new OnPlayerDied());
        }

        Destroy(gameObject);
    }

    protected virtual void PauseEntity(OnPause value) {
        if(this.type == value.type) {
            gameObject.SetActive(false);
        }
    }

    protected virtual void ResumeEntity(OnResume value) {
        if(this.type == value.type) {
            gameObject.SetActive(true);
        }
    }
}
