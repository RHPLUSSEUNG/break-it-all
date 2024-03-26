using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StartFruitType
{
    Classic,
    Arcade,
    PreGameStart,
}

public class StartFruit : MonoBehaviour
{
    [SerializeField] public StartFruitType fruitType;
    [SerializeField] ParticleSystem explosionParticle;

    GameManager gameManager;
    Rigidbody startFruitRb;

    private float maxTorque = 10;
    float fruitTorque;
    Vector3 initPos;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        startFruitRb = transform.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        startFruitRb.useGravity = false;
        if(fruitType == StartFruitType.Classic)
        {
            fruitTorque = 1;
        }
        else if(fruitType == StartFruitType.Arcade)
        {
            fruitTorque = -1;
        }
        else
        {
            fruitTorque = 0.5f;
        }

        initPos = transform.position;
    }

    private void Update()
    {
        startFruitRb.AddTorque(1, -1, fruitTorque, ForceMode.Impulse);

        if (gameManager.gameState == GameState.PreGame && fruitType != StartFruitType.PreGameStart)
        {
            startFruitRb.useGravity = true;
            transform.GetComponent<SphereCollider>().enabled = false;
        }
        else if(gameManager.gameState == GameState.Start && fruitType == StartFruitType.PreGameStart)
        {
            startFruitRb.useGravity = true;
            transform.GetComponent<SphereCollider>().enabled = false;
        }
        else if( gameManager.gameState == GameState.Count)
        {
            startFruitRb.useGravity = false;            
        }
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    public void ExplosionParticle()
    {
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }

    public void ResetPos()
    {        
        transform.position = initPos;        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Mesh"))
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ResetPos();
            transform.gameObject.SetActive(false);
        }
    }
}
