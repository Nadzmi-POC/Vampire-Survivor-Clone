using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityController
{
    public WeaponController weaponController;

    protected override void Initialization()
    {
        base.Initialization();
        weaponController.SetBaseAttack(this.stat.attack);
    }

    protected override void Killed()
    {
        base.Killed();
        Debug.Log("Player died");
    }
}
