using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class TimerController : MonoBehaviour
{
    public static event Action<OnStageTimerStart> OnStageTimerStart;
    public static event Action<OnStageTimerEnd> OnStageTimerEnd;

    private float initDuration;
    private float curDuration;
    private bool isPaused = true;

    private void Update() {
        if (!isPaused && (initDuration > 0)) {
            curDuration -= Time.deltaTime;

            if (!isPaused && curDuration <= 0) {
                TimerEnded();
            }
        }
    }

    public void StartTimer(float duration) {
        OnStageTimerStart?.Invoke(new OnStageTimerStart(duration));

        isPaused = false;
        initDuration = duration;
        curDuration = duration;
    }

    public void StopTimer() {
        isPaused = true;
        curDuration = initDuration;
    }

    private void TimerEnded() {
        OnStageTimerEnd?.Invoke(new OnStageTimerEnd());

        StopTimer();
    }
}
