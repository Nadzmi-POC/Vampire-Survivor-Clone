using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct OnXpChanged
{
    public int currentXp;
    public int xpTreshold;

    public OnXpChanged(int currentXp, int xpTreshold)
    {
        this.currentXp = currentXp;
        this.xpTreshold = xpTreshold;
    }
}
