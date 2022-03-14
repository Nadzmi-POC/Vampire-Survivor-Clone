using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : EntityController
{
    public static event Action<OnEnemyKilled> OnEnemyKilled;

    public EnemyDamageController damageController;

    protected override void Initialization()
    {
        base.Initialization();

        damageController.SetBaseAttack(stat.attack);
    }

    protected override void Killed()
    {
        base.Killed();
        OnEnemyKilled?.Invoke(new OnEnemyKilled(stat.xp));
        Debug.Log("Enemy died");
    }
}
