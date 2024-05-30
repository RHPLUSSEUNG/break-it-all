using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolStuffType
{
    Stuff1,
    Stuff2,
    Stuff3,
    Stuff_Combo,
    Stuff_Slow,
    Bomb_GameOver,
    Bomb_DecTime,
    MAX_SIZE,
}

public class StuffPooler : MonoBehaviour
{
    public static StuffPooler Instance;

    [SerializeField] GameObject stuff1;
    [SerializeField] int stuff1PoolCount;

    [SerializeField] GameObject stuff2;
    [SerializeField] int stuff2PoolCount;

    [SerializeField] GameObject stuff3;
    [SerializeField] int stuff3PoolCount;

    [SerializeField] GameObject stuffCombo;
    [SerializeField] int stuffComboPoolCount;

    [SerializeField] GameObject stuffSlow;
    [SerializeField] int stuffSlowPoolCount;

    [SerializeField] GameObject bombGameOver;
    [SerializeField] int bombGameOverPoolCount;

    [SerializeField] GameObject bombDecTime;
    [SerializeField] int bombDecTimePoolCount;

    List<GameObject>[] stuffPool = new List<GameObject>[(int)PoolStuffType.MAX_SIZE];

    private void Awake()
    {
        Instance = this;

        stuffPool[(int)PoolStuffType.Stuff1] = new List<GameObject>();
        stuffPool[(int)PoolStuffType.Stuff2] = new List<GameObject>();
        stuffPool[(int)PoolStuffType.Stuff3] = new List<GameObject>();
        stuffPool[(int)PoolStuffType.Stuff_Combo] = new List<GameObject>();
        stuffPool[(int)PoolStuffType.Stuff_Slow] = new List<GameObject>();
        stuffPool[(int)PoolStuffType.Bomb_GameOver] = new List<GameObject>();
        stuffPool[(int)PoolStuffType.Bomb_DecTime] = new List<GameObject>();

        for (int i = 0; i < stuff1PoolCount; ++i)
        {
            GameObject _stuff = Instantiate(stuff1);
            _stuff.SetActive(false);
            _stuff.transform.SetParent(transform);

            stuffPool[(int)PoolStuffType.Stuff1].Add(_stuff);
        }

        for (int i = 0; i < stuff2PoolCount; ++i)
        {
            GameObject _stuff = Instantiate(stuff2);
            _stuff.SetActive(false);
            _stuff.transform.SetParent(transform);

            stuffPool[(int)PoolStuffType.Stuff2].Add(_stuff);
        }

        for (int i = 0; i < stuff3PoolCount; ++i)
        {
            GameObject _stuff = Instantiate(stuff3);
            _stuff.SetActive(false);
            _stuff.transform.SetParent(transform);

            stuffPool[(int)PoolStuffType.Stuff3].Add(_stuff);
        }

        for (int i = 0; i < stuffComboPoolCount; ++i)
        {
            GameObject _stuff = Instantiate(stuffCombo);
            _stuff.SetActive(false);
            _stuff.transform.SetParent(transform);

            stuffPool[(int)PoolStuffType.Stuff_Combo].Add(_stuff);
        }

        for (int i = 0; i < stuffSlowPoolCount; ++i)
        {
            GameObject _stuff = Instantiate(stuffSlow);
            _stuff.SetActive(false);
            _stuff.transform.SetParent(transform);

            stuffPool[(int)PoolStuffType.Stuff_Slow].Add(_stuff);
        }

        for (int i = 0; i < bombGameOverPoolCount; ++i)
        {
            GameObject _stuff = Instantiate(bombGameOver);
            _stuff.SetActive(false);
            _stuff.transform.SetParent(transform);

            stuffPool[(int)PoolStuffType.Bomb_GameOver].Add(_stuff);
        }

        for (int i = 0; i < bombDecTimePoolCount; ++i)
        {
            GameObject _stuff = Instantiate(bombDecTime);
            _stuff.SetActive(false);
            _stuff.transform.SetParent(transform);

            stuffPool[(int)PoolStuffType.Bomb_DecTime].Add(_stuff);
        }
    }

    public GameObject GetStuff(PoolStuffType _stuffType)
    {
        if (stuffPool[(int)_stuffType] == null)
        {
            return null;
        }

        for (int i = 0; i < stuffPool[(int)_stuffType].Count; ++i)
        {
            if (!stuffPool[(int)_stuffType][i].activeInHierarchy)
            {
                return stuffPool[(int)_stuffType][i];
            }
        }
        return null;
    }
}
