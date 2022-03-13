using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : EntityController
{
    public EnemyDamageController damageController;

    protected override void Initialization()
    {
        base.Initialization();

        damageController.SetBaseAttack(stat.attack);
    }

    protected override void Killed()
    {
        base.Killed();
        Debug.Log("Enemy died");
    }
}
