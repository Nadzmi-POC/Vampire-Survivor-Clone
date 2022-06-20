using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPopupController : MonoBehaviour
{
    public Canvas uiCanvas;

    private void OnEnable()
    {
        GameController.OnGameOver += ShowGameOver;
    }

    private void OnDisable()
    {
        GameController.OnGameOver -= ShowGameOver;
    }

    private void Start() {
        uiCanvas.enabled = false;
    }

    public void ShowGameOver(OnGameOver value) {
        uiCanvas.enabled = true;
    }
}
