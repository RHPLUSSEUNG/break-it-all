using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StartStuffType
{    
    Classic,
    Arcade,
    PreGameStart,
}

public class StartStuff: MonoBehaviour
{
    [SerializeField] public StartStuffType stuffType;
    [SerializeField] ParticleSystem explosionParticle;

    GameManager gameManager;
    Rigidbody startStuffRb;

    private float maxTorque = 10;
    float stuffTorque;
    Vector3 initPos;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        startStuffRb = transform.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        startStuffRb.useGravity = false;
        if(stuffType == StartStuffType.Classic)
        {
            stuffTorque = 1;
        }
        else if(stuffType == StartStuffType.Arcade)
        {
            stuffTorque = -1;
        }
        else
        {
            stuffTorque = 0.5f;
        }

        initPos = transform.position;
    }

    private void Update()
    {
        startStuffRb.AddTorque(1, -1, stuffTorque, ForceMode.Impulse);

        if (gameManager.gameState == GameState.PreGame && stuffType != StartStuffType.PreGameStart)
        {
            startStuffRb.useGravity = true;
            transform.GetComponent<SphereCollider>().enabled = false;
        }
        else if(gameManager.gameState == GameState.Start && stuffType == StartStuffType.PreGameStart)
        {
            startStuffRb.useGravity = true;
            transform.GetComponent<SphereCollider>().enabled = false;
        }
        else if( gameManager.gameState == GameState.Count)
        {
            startStuffRb.useGravity = false;            
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
