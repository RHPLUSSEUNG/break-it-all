using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]

public class Blade : MonoBehaviour
{
    [SerializeField] GameObject comboTextPivot;
    [SerializeField] Camera cam;
    ComboManager comboManager;
    GameManager gameManager;
    ScoreManager scoreManager;

    ClassicMode classicMode;
    ArcadeMode arcadeMode;

    CameraMove camMove;
    TrailRenderer trail;
    BoxCollider col;
    Vector3 mousePos;
    bool swiping = false;

    public Vector3 direction { get; private set; }
    public float minSliceVelocity = 0.01f;


    private void Awake()
    {
        cam = Camera.main;
        camMove = cam.GetComponent<CameraMove>();
        trail = GetComponent<TrailRenderer>();
        col = GetComponent<BoxCollider>();
        trail.enabled = false;
        col.enabled = false;

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        comboManager = GameObject.Find("Score Manager").GetComponent<ComboManager>();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        classicMode = GameObject.Find("Game Manager").GetComponent<ClassicMode>();
        arcadeMode = GameObject.Find("Game Manager").GetComponent<ArcadeMode>();
    }

    private void Update()
    {
        comboTextPivot.transform.position = transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            swiping = true;
            UpdateComponents();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            swiping = false;
            UpdateComponents();
        }

        if (swiping)
        {
            UpdateMousePosition();
        }
        if (gameManager.gameState == GameState.Pause)
        {
            trail.gameObject.SetActive(false);
        }
        else
        {
            trail.gameObject.SetActive(true);
        }
    }

    void UpdateMousePosition()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = mousePos;
    }

    void UpdateComponents()
    {
        trail.enabled = swiping;
        col.enabled = swiping;
    }

    public void SwapManagement()
    {
        if(swiping)
        {
            swiping = false;
        }
        else
        {
            swiping = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stuff"))
        {
            Stuff _stuff = collision.gameObject.GetComponent<Stuff>();

            if (collision.gameObject.GetComponent<Stuff>())
            {

                switch (_stuff.stuffType)
                {
                    case StuffType.Good:
                        comboManager.AddComboList(collision.gameObject);
                        collision.gameObject.GetComponent<Stuff>().DestroyTarget();
                        break;
                    case StuffType.Slow:
                        collision.gameObject.GetComponent<Stuff>().DestroyTarget();
                        arcadeMode.SlowTime();
                        break;
                    case StuffType.GameOver:                        
                        if(classicMode.shield)
                        {
                            collision.gameObject.GetComponent<Stuff>().DestroyTarget();
                            classicMode.PowerUpShield("consume");
                        }
                        else if(!classicMode.shield)
                        {
                            collision.gameObject.GetComponent<Stuff>().DestroyTarget();
                            gameManager.GameOver();
                        }                        
                        break;
                    case StuffType.DecreaseTime:
                        collision.gameObject.GetComponent<Stuff>().DestroyTarget();
                        arcadeMode.DecreaseTime();
                        break;
                }

            }
        }
        else if (collision.gameObject.CompareTag("Start Stuff"))
        {
            Debug.Log("StartMod");
            if (collision.gameObject.GetComponent<StartStuff>().stuffType == StartStuffType.Classic)
            {
                gameManager.ChooseClassic();
                collision.gameObject.SetActive(false);
                collision.gameObject.GetComponent<StartStuff>().ExplosionParticle();                
            }
            else if (collision.gameObject.GetComponent<StartStuff>().stuffType == StartStuffType.Arcade)
            {
                gameManager.ChooseArcade();
                collision.gameObject.SetActive(false);
                collision.gameObject.GetComponent<StartStuff>().ExplosionParticle();                
            }
            else if (collision.gameObject.GetComponent<StartStuff>().stuffType == StartStuffType.PreGameStart)
            {
                StartCoroutine(gameManager.CountDown());
                collision.gameObject.SetActive(false);
                collision.gameObject.GetComponent<StartStuff>().ExplosionParticle();                
            }
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        Stuff _stuff = collision.gameObject.GetComponent<Stuff>();

        if (collision.gameObject.GetComponent<Stuff>())
        {
            if (_stuff.stuffType == StuffType.Combo)
            {
                camMove.Shake();
                _stuff.ComboParticle();
                _stuff.ComboStuffScoreUpdate();
            }
        }
    }
}