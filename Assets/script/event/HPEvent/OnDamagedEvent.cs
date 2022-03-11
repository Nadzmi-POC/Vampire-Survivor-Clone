using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct OnDamagedEvent
{
    public float value;
    public float curValue;
    public float maxValue;

    public OnDamagedEvent(float value, float curValue, float maxValue)
    {
        this.value = value;
        this.curValue = curValue;
        this.maxValue = maxValue;
    }
}
