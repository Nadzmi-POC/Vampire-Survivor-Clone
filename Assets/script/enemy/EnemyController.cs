using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : EntityController
{
    protected override void Killed()
    {
        base.Killed();
        Debug.Log("Enemy died");
    }
}
