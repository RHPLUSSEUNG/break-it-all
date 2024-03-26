using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArcadeMode : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject arcadeUI;

    GameManager gameManager;
    ScoreManager scoreManager;

    int arcadeScore;
    float gameTimer = 90f;
    float decreaseTime = 10f;
    
    int min;
    int sec;
    bool isSlow;
    float realTime;

    [Header("Power Up Element")]
    float extraTime = 10f;
    float nerfDecTime = 5f;

    private void Start()
    {
        gameManager = transform.GetComponent<GameManager>();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }

    private void Update()
    {
        if (gameManager.gameMode == GameMode.Arcade && gameManager.gameState == GameState.Start)
        {
            arcadeUI.SetActive(true);
            arcadeScore = scoreManager.presentArcadeScore;
            scoreText.text = arcadeScore.ToString();
        }
        if (gameManager.gameState == GameState.Start)
        {
            gameTimer -= Time.deltaTime;
        }
        TimerFunction();
    }

    void TimerFunction()
    {
        if (gameTimer >= 60f)
        {
            min = (int)gameTimer / 60;
            sec = (int)gameTimer % 60;
            timerText.text = "Timer : " + min + ":" + sec;
        }
        else if (gameTimer < 60f && gameTimer > 0)
        {
            timerText.text = "Timer : 0:" + (int)gameTimer;
        }
        else if (gameTimer <= 0)
        {
            timerText.text = "Timer : 0:00";
            gameManager.GameOver();
        }
    }

    public void DecreaseTime()
    {
        gameTimer -= decreaseTime;
    }

    public void SlowTime()
    {
        isSlow = true;
        Time.timeScale = .5f;
        Time.fixedDeltaTime = 0.01f;
        StartCoroutine(SlowTimer());
    }

    IEnumerator SlowTimer()
    {
        yield return new WaitForSecondsRealtime(2);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        isSlow = false;
    }

    public void PowerUpExtraTime(string _switch)
    {
        switch (_switch)
        {
            case "buy":
                gameTimer += extraTime;
                break;            
            default:
                break;
        }
    }

    public void PowerUpNerfBombTime(string _switch)
    {
        switch (_switch)
        {
            case "buy":
                decreaseTime -= nerfDecTime;
                break;            
            default:
                break;
        }
    }
}
