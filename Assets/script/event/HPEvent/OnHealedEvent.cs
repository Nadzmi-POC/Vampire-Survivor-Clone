using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct OnHealedEvent
{
    public float value;
    public float curValue;
    public float maxValue;

    public OnHealedEvent(float value, float curValue, float maxValue)
    {
        this.value = value;
        this.curValue = curValue;
        this.maxValue = maxValue;
    }
}
