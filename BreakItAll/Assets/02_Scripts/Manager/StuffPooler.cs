using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolStuffType
{
    Stuff1,
    Stuff2,
    Stuff3,
    Stuff4,
    Stuff5,
    Stuff6,
    Stuff7,
    Stuff8,
    Stuff9,
    Stuff10,
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

    [SerializeField] GameObject stuff4;
    [SerializeField] int stuff4PoolCount;

    [SerializeField] GameObject stuff5;
    [SerializeField] int stuff5PoolCount;

    [SerializeField] GameObject stuff6;
    [SerializeField] int stuff6PoolCount;

    [SerializeField] GameObject stuff7;
    [SerializeField] int stuff7PoolCount;

    [SerializeField] GameObject stuff8;
    [SerializeField] int stuff8PoolCount;

    [SerializeField] GameObject stuff9;
    [SerializeField] int stuff9PoolCount;

    [SerializeField] GameObject stuff10;
    [SerializeField] int stuff10PoolCount;

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
        stuffPool[(int)PoolStuffType.Stuff4] = new List<GameObject>();
        stuffPool[(int)PoolStuffType.Stuff5] = new List<GameObject>();
        stuffPool[(int)PoolStuffType.Stuff6] = new List<GameObject>();
        stuffPool[(int)PoolStuffType.Stuff7] = new List<GameObject>();
        stuffPool[(int)PoolStuffType.Stuff8] = new List<GameObject>();
        stuffPool[(int)PoolStuffType.Stuff9] = new List<GameObject>();
        stuffPool[(int)PoolStuffType.Stuff10] = new List<GameObject>();
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

        for (int i = 0; i < stuff4PoolCount; ++i)
        {
            GameObject _stuff = Instantiate(stuff4);
            _stuff.SetActive(false);
            _stuff.transform.SetParent(transform);

            stuffPool[(int)PoolStuffType.Stuff4].Add(_stuff);
        }

        for (int i = 0; i < stuff5PoolCount; ++i)
        {
            GameObject _stuff = Instantiate(stuff5);
            _stuff.SetActive(false);
            _stuff.transform.SetParent(transform);

            stuffPool[(int)PoolStuffType.Stuff5].Add(_stuff);
        }

        for (int i = 0; i < stuff6PoolCount; ++i)
        {
            GameObject _stuff = Instantiate(stuff6);
            _stuff.SetActive(false);
            _stuff.transform.SetParent(transform);

            stuffPool[(int)PoolStuffType.Stuff6].Add(_stuff);
        }

        for (int i = 0; i < stuff7PoolCount; ++i)
        {
            GameObject _stuff = Instantiate(stuff7);
            _stuff.SetActive(false);
            _stuff.transform.SetParent(transform);

            stuffPool[(int)PoolStuffType.Stuff7].Add(_stuff);
        }

        for (int i = 0; i < stuff8PoolCount; ++i)
        {
            GameObject _stuff = Instantiate(stuff8);
            _stuff.SetActive(false);
            _stuff.transform.SetParent(transform);

            stuffPool[(int)PoolStuffType.Stuff8].Add(_stuff);
        }

        for (int i = 0; i < stuff9PoolCount; ++i)
        {
            GameObject _stuff = Instantiate(stuff9);
            _stuff.SetActive(false);
            _stuff.transform.SetParent(transform);

            stuffPool[(int)PoolStuffType.Stuff9].Add(_stuff);
        }

        for (int i = 0; i < stuff10PoolCount; ++i)
        {
            GameObject _stuff = Instantiate(stuff10);
            _stuff.SetActive(false);
            _stuff.transform.SetParent(transform);

            stuffPool[(int)PoolStuffType.Stuff10].Add(_stuff);
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
