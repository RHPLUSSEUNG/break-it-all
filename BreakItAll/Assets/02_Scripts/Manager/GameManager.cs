using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameMode
{
    Classic,
    Arcade,
    None,
}

public enum GameState
{
    Start,
    PreGame,
    Count,
    Pause,
    GameOver,
    None,
}

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject preGameUI;
    [SerializeField] GameObject preGameClassicUI;
    [SerializeField] GameObject preGameArcadeUI;
    [SerializeField] GameObject[] titleText;
    [SerializeField] Button restartButton;
    [SerializeField] Button pauseButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button resumeButton;

    [SerializeField] TextMeshProUGUI countText;

    [SerializeField] Blade blade;

    ScoreManager scoreManager;

    [Header("Common Element")]
    public GameMode gameMode;
    public GameState gameState;
    public bool isCount = false;
    public bool init = false;

    [Header("Start Stuff")]
    [SerializeField] GameObject classicStuff;
    [SerializeField] GameObject arcadeStuff;
    [SerializeField] GameObject preGameStuff;

    public bool isBigger;

    private void Awake()
    {
        gameMode = GameMode.None;
        gameState = GameState.None;
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        pauseButton.GetComponent<Button>().onClick.AddListener(PauseFunction);
        resumeButton.GetComponent<Button>().onClick.AddListener(resumeFunction);
        quitButton.GetComponent<Button>().onClick.AddListener(QuitFunction);
    }

    private void Start()
    {
        isBigger = false;
    }

    private void Update()
    {
        UIStateSwitch();
    }

    void UIStateSwitch()
    {
        switch (gameState)
        {
            case GameState.None:
                titleScreen.gameObject.SetActive(true);
                gameOverUI.gameObject.SetActive(false);
                break;
            case GameState.PreGame:
                scoreManager.PreGameScoreText();
                preGameStuff.gameObject.SetActive(true);
                preGameUI.gameObject.SetActive(true);
                titleScreen.gameObject.SetActive(false);
                break;
            case GameState.Count:                
                preGameUI.gameObject.SetActive(false);
                break;
            case GameState.Start:
                pauseButton.gameObject.SetActive(true);
                pauseUI.gameObject.SetActive(false);
                break;
            case GameState.Pause:
                pauseUI.gameObject.SetActive(true);
                pauseButton.gameObject.SetActive(false);
                break;
            case GameState.GameOver:
                gameOverUI.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);
                pauseButton.gameObject.SetActive(false);
                break;
            default:
                break;
        }

    }

    public void ChooseClassic()
    {
        gameMode = GameMode.Classic;
        gameState = GameState.PreGame;
        preGameClassicUI.gameObject.SetActive(true);
    }

    public void ChooseArcade()
    {
        gameMode = GameMode.Arcade;
        gameState = GameState.PreGame;
        preGameArcadeUI.gameObject.SetActive(true);
    }


    public void StartGame()
    {
        gameState = GameState.Start;
    }

    public void GameOver()
    {
        scoreManager.LoadScore();
        scoreManager.CompareScore();
        scoreManager.ScoreText();
        gameState = GameState.GameOver;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        /*
        init = true;
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
        StartStuffControl();        
        */
    }

    public void StartStuffControl()
    {
        if (!classicStuff.activeInHierarchy && !arcadeStuff.activeInHierarchy)
        {
            classicStuff.GetComponent<Rigidbody>().useGravity = false;
            arcadeStuff.GetComponent<Rigidbody>().useGravity = false;
            classicStuff.SetActive(true);
            arcadeStuff.SetActive(true);
        }
    }

    void PauseFunction()
    {
        gameState = GameState.Pause;        
        if (gameState == GameState.Pause)
        {            
            Time.timeScale = 0f;
        }
    }

    void resumeFunction()
    {
        gameState = GameState.Start;
        if (gameState == GameState.Start)
        {
            blade.gameObject.SetActive(true);
            Time.timeScale = 1f;
        }        
    }

    void RetryFuction()
    {
        //[TODO]
    }

    void QuitFunction()
    {
        gameState = GameState.None;
        if (gameState == GameState.None)
        {
            RestartGame();
            Time.timeScale = 1f;
        }
    }

    public void PowerUpIsBigger(string _switch)
    {
        switch (_switch)
        {
            case "buy":
                isBigger = true;
                break;
            default:
                break;
        }
    }
    public IEnumerator CountDown()
    {
        gameState = GameState.Count;
        scoreManager.SetPresentScore();        
        countText.gameObject.SetActive(true);
        countText.text = "3";
        yield return new WaitForSeconds(1);
        countText.text = "2";
        yield return new WaitForSeconds(1);
        countText.text = "1";
        yield return new WaitForSeconds(1);
        countText.gameObject.SetActive(false);        
        StartGame();
    }

}
