using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerXpController : MonoBehaviour
{
    public static event Action<OnXpChanged> OnExpChanged;
    public static event Action<OnLevelUp> OnLevelUp;

    private int level = 1;
    private int xp = 0;
    private int xpTreshold = 100;

    private void OnEnable()
    {
        EnemyController.OnEnemyKilled += ReceiveXp;
    }

    private void OnDisable()
    {
        EnemyController.OnEnemyKilled -= ReceiveXp;
    }

    public void ReceiveXp(OnEnemyKilled value)
    {
        xp += value.xp;
        OnExpChanged?.Invoke(new OnXpChanged(value.xp));

        if (xp >= xpTreshold)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        level += 1;
        xp -= xpTreshold;
        xpTreshold = xpTreshold * level;
        OnLevelUp?.Invoke(new OnLevelUp(level));
    }
}