using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class GameOverController : MonoBehaviour
{
    public static event Action<OnGameOver> OnGameOver;

    private bool isWinning = false;

    private void OnEnable() {
        GameController.OnGameOver += GameOver;
    }

    private void OnDisable() {
        GameController.OnGameOver -= GameOver;
    }

    public void GameOver(OnGameOver value) {
        this.isWinning = value.isWinning;
        Debug.Log("Game Over: " + this.isWinning);
    }
}
