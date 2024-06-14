using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class ScoreData
{
    public bool isFirst = true;
    public int[] classicScore;
    public int[] arcadeScore;
}

public class ScoreManager : MonoBehaviour
{
    public ScoreData scoreData;
    GameManager gameManager;
    ClassicMode classicMode;

    [SerializeField] TextMeshProUGUI classicBestScore;
    [SerializeField] TextMeshProUGUI arcadeBestScore;

    [SerializeField] Image lifePlusImage;

    [SerializeField] TextMeshProUGUI[] scoreTextArr;
    [SerializeField] TextMeshProUGUI[] preGameScoreTextArr;
    [SerializeField] TextMeshProUGUI presentScore;
   
    int rankIndex = 5;
    int lifeScore;

    public int presentClassicScore;
    public int presentArcadeScore;

    int extraScore = 10;
    bool isExtraScore;

    Vector3 lifeImgPos;

    private void Awake()
    {
        LoadScore();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        classicMode = GameObject.Find("Game Manager").GetComponent<ClassicMode>();
    }

    void Start()
    {
        lifeScore = 0;

        if (scoreData.isFirst)
        {
            scoreData.classicScore = new int[5];
            scoreData.arcadeScore = new int[5];

            for (int i = 0; i < rankIndex; ++i)
            {
                scoreData.classicScore[i] = 0;
                scoreData.arcadeScore[i] = 0;
            }
            scoreData.isFirst = false;
            SaveScore();
        }
    }

    private void Update()
    {
        switch (gameManager.gameMode)
        {
            case GameMode.Classic:
                if (presentClassicScore > scoreData.classicScore[0])
                {
                    classicBestScore.text = "Best : " + presentClassicScore;
                }
                else
                {
                    classicBestScore.text = "Best : " + scoreData.classicScore[0];
                }
                break;
            case GameMode.Arcade:
                if (presentArcadeScore > scoreData.arcadeScore[0])
                {
                    arcadeBestScore.text = "Best : " + presentArcadeScore;
                }
                else
                {
                    arcadeBestScore.text = "Best : " + scoreData.arcadeScore[0];
                }
                break;
        }

    }

    public void SetPresentScore()
    {
        presentArcadeScore = 0;
        presentClassicScore = 0;
    }

    public void UpdateScore(int scoreToAdd)
    {
        switch (gameManager.gameMode)
        {
            case GameMode.Classic:
                if(isExtraScore)
                {
                    presentClassicScore += scoreToAdd + extraScore;
                }
                else
                {
                    presentClassicScore += scoreToAdd;
                }
                
                if(classicMode.lives < 3)
                {
                    lifeScore += scoreToAdd;
                }                
                break;
            case GameMode.Arcade:
                presentArcadeScore += scoreToAdd;
                break;
        }                
    }

    public void LifePlus(Vector3 _pos)
    {
        lifeImgPos = _pos;

        if (lifeScore >= 100 && !classicMode.isFullLife)
        {
            classicMode.increaseLife();
            Instantiate(lifePlusImage, lifeImgPos, Quaternion.identity, GameObject.Find("Classic Mode UI").transform);
            lifeScore = 0;
        }
    }

    public void PowerUpExtraScore(string _switch)
    {
        switch (_switch)
        {
            case "buy":
                isExtraScore = true;
                break;
            default:
                break;
        }
    }

    public void ScoreText()
    {
        switch (gameManager.gameMode)
        {
            case GameMode.Classic:
                for (int i = 0; i < scoreData.classicScore.Length; i++)
                {
                    scoreTextArr[i].text = scoreData.classicScore[i].ToString();
                    presentScore.text = presentClassicScore.ToString();
                }
                break;
            case GameMode.Arcade:
                for (int i = 0; i < scoreData.arcadeScore.Length; i++)
                {
                    scoreTextArr[i].text = scoreData.arcadeScore[i].ToString();
                    presentScore.text = presentArcadeScore.ToString();
                }
                break;
            default:
                break;
        }
        
    }

    public void PreGameScoreText()
    {
        switch (gameManager.gameMode)
        {
            case GameMode.Classic:
                for (int i = 0; i < scoreData.classicScore.Length; i++)
                {
                    preGameScoreTextArr[i].text = scoreData.classicScore[i].ToString();                    
                }
                break;
            case GameMode.Arcade:
                for (int i = 0; i < scoreData.arcadeScore.Length; i++)
                {
                    preGameScoreTextArr[i].text = scoreData.arcadeScore[i].ToString();                    
                }
                break;
            default:
                break;
        }
    }


    [ContextMenu("To Json")]
    public void SaveScore()
    {
        string json = JsonUtility.ToJson(scoreData, true);
        string path = Application.dataPath + "/Resources/ScoreData/ScoreData.json";
        File.WriteAllText(path, json);
    }


    public void LoadScore()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("ScoreData/ScoreData");
        if (textAsset != null)
        {
            scoreData = JsonUtility.FromJson<ScoreData>(textAsset.text);
        }
        else
        {
            Debug.LogError("Failed to load score data.");
        }
    }

    public void CompareScore()
    {
        if (presentClassicScore > scoreData.classicScore[4])
        {
            scoreData.classicScore[4] = presentClassicScore;
            Array.Sort(scoreData.classicScore);
            Array.Reverse(scoreData.classicScore);
            SaveScore();
        }
        if (presentArcadeScore > scoreData.arcadeScore[4])
        {
            scoreData.arcadeScore[4] = presentArcadeScore;
            Array.Sort(scoreData.arcadeScore);
            Array.Reverse(scoreData.arcadeScore);
            SaveScore();
        }
    }
}
