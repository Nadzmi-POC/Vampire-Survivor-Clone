using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class GameController : MonoBehaviour
{
    public static event Action<OnGameOver> OnGameOver;
    public static event Action<OnPause> OnPause;
    public static event Action<OnResume> OnResume;

    public bool isWinning = false;

    private void OnEnable() {
        EntityController.OnPlayerDied += PlayerDied;
    }

    private void OnDisable() {
        EntityController.OnPlayerDied -= PlayerDied;
    }

    public void TriggerGameOver(bool isWinning) {
        this.isWinning = isWinning;

        OnGameOver?.Invoke(new OnGameOver(isWinning));
        OnPause?.Invoke(new OnPause(EntityType.player));
        OnPause?.Invoke(new OnPause(EntityType.enemy));
    }

    public void PlayerDied(OnPlayerDied value) {
        TriggerGameOver(false);
    }
}
