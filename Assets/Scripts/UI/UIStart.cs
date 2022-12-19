using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStart : UIManager
{
    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnHighscore;
    [SerializeField] private Button btnExit;

    private void Start()
    {
        this.btnStart.onClick.AddListener(StartGame);
        this.btnHighscore.onClick.AddListener(OpenHighscorePopup);
        this.btnExit.onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        Destroy(gameObject);
        GameManager.Instance.StartGame();
    }

    private void OpenHighscorePopup()
    {
        LoadHighScorePopup();
    }

    private void ExitGame()
    {
        QuitGame();
    }
}
