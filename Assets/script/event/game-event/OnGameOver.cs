using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct OnGameOver
{
    public bool isWinning;

    public OnGameOver(bool isWinning)
    {
        this.isWinning = isWinning;
    }
}
