using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPopupController : MonoBehaviour
{
    public Canvas uiCanvas;
    public Text txtGameOver;

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

        if(value.isWinning) {
            txtGameOver.text = "You win!";
        } else {
            txtGameOver.text = "You lose!";
        }
    }
}
