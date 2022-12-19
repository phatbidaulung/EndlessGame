using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private float timeNow;

    private void Awake()
    {
        Instance = this;
        this.StopGame();
    }
    private void Update()
    {
        this.UpdateTime();
        //Debug.Log(timeNow);
        IncreaseSpeedEnemy();
    }

    private void UpdateTime()
    {
        int variableTime = 10;
        timeNow += variableTime * Time.deltaTime;
    }

    public void GameOver()
    {
        this.StopGame();
        Debug.Log("Game Over");
        if(TimeIs() > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", TimeIs());
            Debug.Log(PlayerPrefs.GetInt("highScore"));
            //Tao popup luu diem
            Instantiate(Resources.Load<GameObject>("Popups/InputHighscore") as GameObject);
            
        }
        Instantiate(Resources.Load<GameObject>("Popups/PlayerAgain") as GameObject);
        
    }

    public void StopGame()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
    }

    public int TimeIs() => (int)timeNow;

        float timeIncrease;
        int levelSpeed;
    public void IncreaseSpeedEnemy()
    {
        int variableTime = 10;
        timeIncrease += variableTime * Time.deltaTime;
        if(timeIncrease >= 100f)
        {
            levelSpeed++;
            timeIncrease = 0f;
        }
    }

    public int ReturnLevelSpeed() => levelSpeed;

}
