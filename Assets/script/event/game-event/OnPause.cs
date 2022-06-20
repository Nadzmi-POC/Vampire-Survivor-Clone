using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct OnPause
{
    public EntityType type;

    public OnPause(EntityType type)
    {
        this.type = type;
    }
}
