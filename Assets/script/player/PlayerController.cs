using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityController
{
    protected override void Killed()
    {
        base.Killed();
        Debug.Log("Player died");
    }
}
