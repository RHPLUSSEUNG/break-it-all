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



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            Fruit _fruit = collision.gameObject.GetComponent<Fruit>();

            if (collision.gameObject.GetComponent<Fruit>())
            {

                switch (_fruit.fruitType)
                {
                    case FruitType.Good:
                        comboManager.AddComboList(collision.gameObject);
                        collision.gameObject.GetComponent<Fruit>().DestroyTarget();
                        break;
                    case FruitType.Slow:
                        collision.gameObject.GetComponent<Fruit>().DestroyTarget();
                        arcadeMode.SlowTime();
                        break;
                    case FruitType.GameOver:                        
                        if(classicMode.shield)
                        {
                            collision.gameObject.GetComponent<Fruit>().DestroyTarget();
                            classicMode.PowerUpShield("consume");
                        }
                        else if(!classicMode.shield)
                        {
                            collision.gameObject.GetComponent<Fruit>().DestroyTarget();
                            gameManager.GameOver();
                        }                        
                        break;
                    case FruitType.DecreaseTime:
                        collision.gameObject.GetComponent<Fruit>().DestroyTarget();
                        arcadeMode.DecreaseTime();
                        break;
                }

            }
        }
        else if (collision.gameObject.CompareTag("Start Fruit"))
        {

            if (collision.gameObject.GetComponent<StartFruit>().fruitType == StartFruitType.Classic)
            {
                collision.gameObject.SetActive(false);
                collision.gameObject.GetComponent<StartFruit>().ExplosionParticle();
                gameManager.ChooseClassic();
            }
            else if (collision.gameObject.GetComponent<StartFruit>().fruitType == StartFruitType.Arcade)
            {
                collision.gameObject.SetActive(false);
                collision.gameObject.GetComponent<StartFruit>().ExplosionParticle();
                gameManager.ChooseArcade();
            }
            else if (collision.gameObject.GetComponent<StartFruit>().fruitType == StartFruitType.PreGameStart)
            {
                collision.gameObject.SetActive(false);
                collision.gameObject.GetComponent<StartFruit>().ExplosionParticle();
                StartCoroutine(gameManager.CountDown());
            }
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        Fruit _fruit = collision.gameObject.GetComponent<Fruit>();

        if (collision.gameObject.GetComponent<Fruit>())
        {
            if (_fruit.fruitType == FruitType.Combo)
            {
                camMove.Shake();
                _fruit.ComboParticle();
                _fruit.ComboFruitScoreUpdate();
            }
        }
    }
}