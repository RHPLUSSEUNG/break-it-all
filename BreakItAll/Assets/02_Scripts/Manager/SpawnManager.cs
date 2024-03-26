using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    [SerializeField] SpawnPatternScriptableObject spawnData;
    GameManager gameManager;

    float patternTimer;
    float fruitTimer;

    int patternIndex = 0;
    int fruitIndex = 0;

    private float maxTorque = 10;

    [HideInInspector] public int sliceAllFruit;
    [HideInInspector] public int[] sliceFruit = new int[(int)FruitType.MAX_SIZE];

    private void Awake()
    {
        Instance = this;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(gameManager.gameState == GameState.Start)
        {
            Spawn();
        }        
    }

    void Spawn()
    {
        patternTimer += Time.deltaTime;

        if(patternTimer > spawnData.spawnPattern[patternIndex].patternTimer && patternIndex < spawnData.spawnPattern.Length)
        {
            fruitTimer += Time.deltaTime;            
        }

        if (fruitTimer > spawnData.spawnPattern[patternIndex].spawnElementData[fruitIndex].spawnTime && fruitIndex < spawnData.spawnPattern[patternIndex].spawnElementData.Length)
        {
            float _forceFactor = spawnData.spawnPattern[patternIndex].spawnElementData[fruitIndex].forceFactor;
            Vector3 _spawnPosition = spawnData.spawnPattern[patternIndex].spawnElementData[fruitIndex].spawnPosition;
            PoolFruitType _fruitType = spawnData.spawnPattern[patternIndex].spawnElementData[fruitIndex].fruitType;
            GameObject _fruit;

            switch (_fruitType)
            {
                case PoolFruitType.Fruit1:
                    _fruit = FruitPooler.Instance.GetFruit(PoolFruitType.Fruit1);
                    if (_fruit)
                    {
                        _fruit.SetActive(true);
                        _fruit.transform.position = _spawnPosition;
                        _fruit.GetComponent<Rigidbody>().AddForce(Vector3.up * _forceFactor, ForceMode.Impulse);
                        _fruit.GetComponent<Rigidbody>().AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
                    }
                    break;
                case PoolFruitType.Fruit2:
                    _fruit = FruitPooler.Instance.GetFruit(PoolFruitType.Fruit2);
                    if (_fruit)
                    {
                        _fruit.SetActive(true);
                        _fruit.transform.position = _spawnPosition;
                        _fruit.GetComponent<Rigidbody>().AddForce(Vector3.up * _forceFactor, ForceMode.Impulse);
                        _fruit.GetComponent<Rigidbody>().AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
                    }
                    break;
                case PoolFruitType.Fruit3:
                    _fruit = FruitPooler.Instance.GetFruit(PoolFruitType.Fruit3);
                    if (_fruit)
                    {
                        _fruit.SetActive(true);
                        _fruit.transform.position = _spawnPosition;
                        _fruit.GetComponent<Rigidbody>().AddForce(Vector3.up * _forceFactor, ForceMode.Impulse);
                        _fruit.GetComponent<Rigidbody>().AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
                    }
                    break;
                case PoolFruitType.Fruit_Combo:
                    _fruit = FruitPooler.Instance.GetFruit(PoolFruitType.Fruit_Combo);
                    if (_fruit)
                    {
                        _fruit.SetActive(true);
                        _fruit.transform.position = _spawnPosition;
                        _fruit.GetComponent<Rigidbody>().AddForce(Vector3.up * _forceFactor, ForceMode.Impulse);
                        _fruit.GetComponent<Rigidbody>().AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
                    }
                    break;
                case PoolFruitType.Fruit_Slow:
                    _fruit = FruitPooler.Instance.GetFruit(PoolFruitType.Fruit_Slow);
                    if (_fruit)
                    {
                        _fruit.SetActive(true);
                        _fruit.transform.position = _spawnPosition;
                        _fruit.GetComponent<Rigidbody>().AddForce(Vector3.up * _forceFactor, ForceMode.Impulse);
                        _fruit.GetComponent<Rigidbody>().AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
                    }
                    break;
                case PoolFruitType.Bomb_GameOver:
                    _fruit = FruitPooler.Instance.GetFruit(PoolFruitType.Bomb_GameOver);
                    if (_fruit)
                    {
                        _fruit.SetActive(true);
                        _fruit.transform.position = _spawnPosition;
                        _fruit.GetComponent<Rigidbody>().AddForce(Vector3.up * _forceFactor, ForceMode.Impulse);
                        _fruit.GetComponent<Rigidbody>().AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
                    }
                    break;
                case PoolFruitType.Bomb_DecTime:
                    _fruit = FruitPooler.Instance.GetFruit(PoolFruitType.Bomb_DecTime);
                    if (_fruit)
                    {
                        _fruit.SetActive(true);
                        _fruit.transform.position = _spawnPosition;
                        _fruit.GetComponent<Rigidbody>().AddForce(Vector3.up * _forceFactor, ForceMode.Impulse);
                        _fruit.GetComponent<Rigidbody>().AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
                    }
                    break;
            }

            ++fruitIndex;
            fruitTimer = 0;

            if(fruitIndex >= spawnData.spawnPattern[patternIndex].spawnElementData.Length)
            {
                fruitIndex = 0;
                ++patternIndex;

                patternTimer = 0;

                if(patternIndex >= spawnData.spawnPattern.Length)
                {
                    patternIndex = 0;
                }
            }
        }
    }

    public void Despawn(FruitType _type)
    {
        switch(_type)
        {
            case FruitType.Good:
                sliceFruit[(int)FruitType.Good]++;
                sliceAllFruit++;
                break;
            case FruitType.Combo:
                sliceFruit[(int)FruitType.Combo]++;
                sliceAllFruit++;
                break;
            case FruitType.Slow:
                sliceFruit[(int)FruitType.Slow]++;
                sliceAllFruit++;
                break;
            case FruitType.DecreaseTime:
                sliceFruit[(int)FruitType.DecreaseTime]++;
                sliceAllFruit++;
                break;
            case FruitType.GameOver:
                sliceFruit[(int)FruitType.GameOver]++;
                sliceAllFruit++;
                break;
        }
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

}

