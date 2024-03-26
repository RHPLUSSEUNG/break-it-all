using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PowerType
{
    Shield_C,
    ExtraLife_C,
    ExtraTime_A,
    NerfBombTime_A,
    Critical_CA,
    BiggerFruit_CA,
    ExtraScore_CA,
    Max_Size,
}

public class PowerUp : MonoBehaviour
{
    [SerializeField] public int coin;
    [SerializeField] Button[] powerButton;
    GameManager gameManager;
    ScoreManager scoreManager;
    ClassicMode classicMode;
    ArcadeMode arcadeMode;
    

    private void Start()
    {        
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        classicMode = GameObject.Find("Game Manager").GetComponent<ClassicMode>();
        arcadeMode = GameObject.Find("Game Manager").GetComponent<ArcadeMode>();

        powerButton = new Button[(int)PowerType.Max_Size];
    }

    public void IncreaseCoin()
    {
        ++coin;
    }

    public void DecreaseCoin(int pay)
    {
        if (coin >= pay)
        {
            coin -= pay;
        }
        else
        {
            //[TODO]
        }
    }

    void PowerUpButton()
    {
        if (gameManager.gameMode == GameMode.Classic)
        {
            Button[] classicPowerUp = new Button[4];

            for (int i = 0; i < classicPowerUp.Length; i++)
            {
                
            }
        }
        else if(gameManager.gameMode == GameMode.Arcade)
        {

        }
    }

    public void Shield()
    {
        classicMode.PowerUpShield("buy");
    }

    public void ExtraLife()
    {
        classicMode.PowerUpExtraLife("buy");
    }

    public void ExtraTime()
    {
        arcadeMode.PowerUpExtraTime("buy");
    }

    public void NerfBombTime()
    {
        arcadeMode.PowerUpNerfBombTime("buy");
    }

    public void Critical()
    {
        //[TODO]
    }

    public void BiggerFruit()
    {
        gameManager.PowerUpIsBigger("buy");
    }

    public void ExtraScore()
    {
        scoreManager.PowerUpExtraScore("buy");
    }
}
