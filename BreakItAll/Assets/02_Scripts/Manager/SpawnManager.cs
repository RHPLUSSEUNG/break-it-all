using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    [SerializeField] SpawnPatternScriptableObject spawnData;
    GameManager gameManager;

    float patternTimer;
    float stuffTimer;

    int patternIndex = 0;
    int stuffIndex = 0;

    private float maxTorque = 10;

    [HideInInspector] public int sliceAllStuff;
    [HideInInspector] public int[] sliceStuff = new int[(int)StuffType.MAX_SIZE];

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
            stuffTimer += Time.deltaTime;            
        }

        if (stuffTimer > spawnData.spawnPattern[patternIndex].spawnElementData[stuffIndex].spawnTime && stuffIndex < spawnData.spawnPattern[patternIndex].spawnElementData.Length)
        {
            float _forceFactor = spawnData.spawnPattern[patternIndex].spawnElementData[stuffIndex].forceFactor;
            Vector3 _spawnPosition = spawnData.spawnPattern[patternIndex].spawnElementData[stuffIndex].spawnPosition;
            PoolStuffType _stuffType = spawnData.spawnPattern[patternIndex].spawnElementData[stuffIndex].stuffType;
            if(gameManager.gameMode == GameMode.Arcade)
            {
                if(_stuffType == PoolStuffType.Bomb_GameOver)
                {
                    _stuffType = PoolStuffType.Bomb_DecTime;
                }
            }
            GameObject _stuff;

            switch (_stuffType)
            {
                case PoolStuffType.Stuff1:
                case PoolStuffType.Stuff2:
                case PoolStuffType.Stuff3:
                case PoolStuffType.Stuff4:
                case PoolStuffType.Stuff5:
                case PoolStuffType.Stuff6:
                case PoolStuffType.Stuff7:
                case PoolStuffType.Stuff8:
                case PoolStuffType.Stuff9:
                case PoolStuffType.Stuff10:
                    _stuff = StuffPooler.Instance.GetStuff(_stuffType);
                    if (_stuff)
                    {
                        _stuff.SetActive(true);
                        _stuff.transform.position = _spawnPosition;
                        _stuff.GetComponent<Rigidbody>().AddForce(Vector3.up * _forceFactor, ForceMode.Impulse);
                        _stuff.GetComponent<Rigidbody>().AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
                    }
                    break;
                case PoolStuffType.Stuff_Combo:
                    _stuff = StuffPooler.Instance.GetStuff(PoolStuffType.Stuff_Combo);
                    if (_stuff)
                    {
                        _stuff.SetActive(true);
                        _stuff.transform.position = _spawnPosition;
                        _stuff.GetComponent<Rigidbody>().AddForce(Vector3.up * _forceFactor, ForceMode.Impulse);
                        _stuff.GetComponent<Rigidbody>().AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
                    }
                    break;
                case PoolStuffType.Stuff_Slow:
                    _stuff = StuffPooler.Instance.GetStuff(PoolStuffType.Stuff_Slow);
                    if (_stuff)
                    {
                        _stuff.SetActive(true);
                        _stuff.transform.position = _spawnPosition;
                        _stuff.GetComponent<Rigidbody>().AddForce(Vector3.up * _forceFactor, ForceMode.Impulse);
                        _stuff.GetComponent<Rigidbody>().AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
                    }
                    break;
                case PoolStuffType.Bomb_GameOver:
                    _stuff = StuffPooler.Instance.GetStuff(PoolStuffType.Bomb_GameOver);
                    if (_stuff)
                    {
                        _stuff.SetActive(true);
                        _stuff.transform.position = _spawnPosition;
                        _stuff.GetComponent<Rigidbody>().AddForce(Vector3.up * _forceFactor, ForceMode.Impulse);
                        _stuff.GetComponent<Rigidbody>().AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
                    }
                    break;
                case PoolStuffType.Bomb_DecTime:
                    _stuff = StuffPooler.Instance.GetStuff(PoolStuffType.Bomb_DecTime);
                    if (_stuff)
                    {
                        _stuff.SetActive(true);
                        _stuff.transform.position = _spawnPosition;
                        _stuff.GetComponent<Rigidbody>().AddForce(Vector3.up * _forceFactor, ForceMode.Impulse);
                        _stuff.GetComponent<Rigidbody>().AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
                    }
                    break;
            }

            ++stuffIndex;
            stuffTimer = 0;

            if(stuffIndex >= spawnData.spawnPattern[patternIndex].spawnElementData.Length)
            {
                stuffIndex = 0;
                ++patternIndex;

                patternTimer = 0;

                if(patternIndex >= spawnData.spawnPattern.Length)
                {
                    patternIndex = Random.Range(0, spawnData.spawnPattern.Length);
                }
            }
        }
    }

    public void Despawn(StuffType _type)
    {
        switch(_type)
        {
            case StuffType.Good:
                sliceStuff[(int)StuffType.Good]++;
                sliceAllStuff++;
                break;
            case StuffType.Combo:
                sliceStuff[(int)StuffType.Combo]++;
                sliceAllStuff++;
                break;
            case StuffType.Slow:
                sliceStuff[(int)StuffType.Slow]++;
                sliceAllStuff++;
                break;
            case StuffType.DecreaseTime:
                sliceStuff[(int)StuffType.DecreaseTime]++;
                sliceAllStuff++;
                break;
            case StuffType.GameOver:
                sliceStuff[(int)StuffType.GameOver]++;
                sliceAllStuff++;
                break;
        }
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

}

