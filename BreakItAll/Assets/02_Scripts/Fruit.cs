using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FruitType
{
    Good,
    Combo,
    Slow,
    GameOver,
    DecreaseTime,
    MAX_SIZE,
}

public class Fruit : MonoBehaviour
{
    private GameManager gameManager;
    ScoreManager scoreManager;
    ClassicMode classicMode;
    ComboManager comboManager;
    [SerializeField] public FruitType fruitType;
    [SerializeField] public int pointValue;
    [SerializeField] ParticleSystem explosionParticle;

    Vector3 imgPos;

    int comboScore;
    

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        classicMode = GameObject.Find("Game Manager").GetComponent<ClassicMode>();
        comboManager = GameObject.Find("Score Manager").GetComponent<ComboManager>();
    }

    private void Start()
    {
        comboScore = 0;

        if(gameManager.isBigger)
        {
            PowerUpBiggerFruit();
        }
    }

    public void DestroyTarget()
    {
        if (gameManager.gameState == GameState.Start)
        {
            SetComboImagePos();
            
            comboManager.coPosSet(imgPos);
            scoreManager.LifePlus(imgPos);            
            scoreManager.UpdateScore(pointValue);

            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.SetParent(transform);

            gameObject.SetActive(false);

            SpawnManager.Instance.Despawn(fruitType);
        }
    }

    public void ComboParticle()
    {
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }

    public void SetComboImagePos()
    {
        imgPos = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, 0));
    }

    public void PowerUpBiggerFruit()
    {        
        transform.localScale = new Vector3(3f,3f,3f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ComboMesh") && fruitType == FruitType.Combo)
        {
            StartCoroutine(ComboBoom(other));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mesh"))
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.SetParent(transform);
            gameObject.SetActive(false);
            if (gameManager.gameMode == GameMode.Classic)
            {
                classicMode.decreaseLives(1);
            }
        }
    }

    IEnumerator ComboBoom(Collider other)
    {
        yield return new WaitForSeconds(4f);

        gameObject.SetActive(false);
        other.GetComponent<ComboMeshTrigger>().SetTargetInComboMesh(false);
        scoreManager.UpdateScore(comboScore);
        comboScore = 0;
    }

    public void ComboFruitScoreUpdate()
    {
        comboScore += pointValue;
    }

   

}
