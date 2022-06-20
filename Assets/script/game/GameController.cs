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

    public float StageDuration;
    public TimerController timerController;

    private bool isWinning = false;

    private void Start() {
        timerController.StartTimer(StageDuration);
    }

    private void OnEnable() {
        EntityController.OnPlayerDied += PlayerDied;
        TimerController.OnStageTimerStart += StageTimerStarted;
        TimerController.OnStageTimerEnd += StageTimerEnded;
    }

    private void OnDisable() {
        EntityController.OnPlayerDied -= PlayerDied;
        TimerController.OnStageTimerStart -= StageTimerStarted;
        TimerController.OnStageTimerEnd -= StageTimerEnded;
    }

    public void TriggerGameOver(bool isWinning) {
        this.isWinning = isWinning;

        OnGameOver?.Invoke(new OnGameOver(isWinning));
        OnPause?.Invoke(new OnPause(EntityType.player));
        OnPause?.Invoke(new OnPause(EntityType.enemy));

        Debug.Log("Game Over: " + this.isWinning);
    }

    public void PlayerDied(OnPlayerDied value) {
        TriggerGameOver(false);
        timerController.StopTimer();
    }

    public void StageTimerStarted(OnStageTimerStart value) {
        Debug.Log("Game Start");
    }

    public void StageTimerEnded(OnStageTimerEnd value) {
        TriggerGameOver(true);
    }
}
