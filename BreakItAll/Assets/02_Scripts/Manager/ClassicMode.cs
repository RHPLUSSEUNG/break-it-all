using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClassicMode : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] GameObject classicUI;

    [SerializeField] Image[] blueX;
    [SerializeField] Image[] redX;

    GameManager gameManager;
    ScoreManager scoreManager;

    
    public bool isFullLife;
    public int lives = 3;
    public bool shield;
    public bool extraLife;
    int classicScore;
    bool isGameEnd;

    private void Start()
    {
        isFullLife = true;
        isGameEnd = false;
        shield = false;

        gameManager = transform.GetComponent<GameManager>();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        initElement();

        for (int i = 0; i < 3; ++i)
        {
            blueX[i].gameObject.SetActive(true);
            redX[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (gameManager.gameMode == GameMode.Classic && gameManager.gameState == GameState.Start)
        {
            classicUI.SetActive(true);
            classicScore = scoreManager.presentClassicScore;
            scoreText.text = classicScore.ToString();
        }

        if (lives == 0 && !isGameEnd)
        {
            isGameEnd = true;
            gameManager.GameOver();
        }
    }

    void ChangeLifeImage()
    {
        switch (lives)
        {
            case 3:
                isFullLife = true;
                for (int i = 0; i < blueX.Length; ++i)
                {
                    blueX[i].gameObject.SetActive(true);
                    redX[i].gameObject.SetActive(false);
                }
                break;
            case 2:
                isFullLife = false;
                blueX[0].gameObject.SetActive(false);
                redX[0].gameObject.SetActive(true);
                break;
            case 1:
                isFullLife = false;
                for (int i = 0; i < 2; ++i)
                {
                    blueX[i].gameObject.SetActive(false);
                    redX[i].gameObject.SetActive(true);
                }
                break;
            case 0:
                isFullLife = false;
                for (int i = 0; i < 3; ++i)
                {
                    blueX[i].gameObject.SetActive(false);
                    redX[i].gameObject.SetActive(true);
                }
                break;
        }
    }

    public void increaseLife()
    {
        lives += 1;
        ChangeLifeImage();        
    }

    public void decreaseLives(int _lives)
    {
        if (lives > 0 && !extraLife)
        {
            lives -= _lives;
            ChangeLifeImage();
        }
        else if(extraLife)
        {
            PowerUpExtraLife("consume");
        }
    }

    void initElement()
    {
        if (gameManager.init)
        {
            lives = 3;
            classicScore = 0;
        }

    }

    public void PowerUpShield(string _switch)
    {
        switch (_switch)
        {
            case "buy":
                shield = true;
                break;
            case "consume":
                shield = false;
                break;
            default:
                break;
        }        
    }

    public void PowerUpExtraLife(string _switch)
    {
        switch (_switch)
        {
            case "buy":
                extraLife = true;
                break;
            case "consume":
                extraLife = false;
                break;
            default:
                break;
        }
    }
}
