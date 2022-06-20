using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct OnResume
{
    public EntityType type;

    public OnResume(EntityType type)
    {
        this.type = type;
    }
}
