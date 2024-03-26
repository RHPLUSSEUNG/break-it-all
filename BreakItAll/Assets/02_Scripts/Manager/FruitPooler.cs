using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolFruitType
{
    Fruit1,
    Fruit2,
    Fruit3,
    Fruit_Combo,
    Fruit_Slow,
    Bomb_GameOver,
    Bomb_DecTime,
    MAX_SIZE,
}
public class FruitPooler : MonoBehaviour
{
    public static FruitPooler Instance;

    [SerializeField] GameObject fruit1;
    [SerializeField] int fruit1PoolCount;

    [SerializeField] GameObject fruit2;
    [SerializeField] int fruit2PoolCount;

    [SerializeField] GameObject fruit3;
    [SerializeField] int fruit3PoolCount;

    [SerializeField] GameObject fruitCombo;
    [SerializeField] int fruitComboPoolCount;

    [SerializeField] GameObject fruitSlow;
    [SerializeField] int fruitSlowPoolCount;

    [SerializeField] GameObject bombGameOver;
    [SerializeField] int bombGameOverPoolCount;

    [SerializeField] GameObject bombDecTime;
    [SerializeField] int bombDecTimePoolCount;

    List<GameObject>[] fruitPool = new List<GameObject>[(int)PoolFruitType.MAX_SIZE];

    private void Awake()
    {
        Instance = this;

        fruitPool[(int)PoolFruitType.Fruit1] = new List<GameObject>();
        fruitPool[(int)PoolFruitType.Fruit2] = new List<GameObject>();
        fruitPool[(int)PoolFruitType.Fruit3] = new List<GameObject>();
        fruitPool[(int)PoolFruitType.Fruit_Combo] = new List<GameObject>();
        fruitPool[(int)PoolFruitType.Fruit_Slow] = new List<GameObject>();
        fruitPool[(int)PoolFruitType.Bomb_GameOver] = new List<GameObject>();
        fruitPool[(int)PoolFruitType.Bomb_DecTime] = new List<GameObject>();

        for (int i = 0; i < fruit1PoolCount; ++i)
        {
            GameObject _fruit = Instantiate(fruit1);
            _fruit.SetActive(false);
            _fruit.transform.SetParent(transform);

            fruitPool[(int)PoolFruitType.Fruit1].Add(_fruit);
        }

        for (int i = 0; i < fruit2PoolCount; ++i)
        {
            GameObject _fruit = Instantiate(fruit2);
            _fruit.SetActive(false);
            _fruit.transform.SetParent(transform);

            fruitPool[(int)PoolFruitType.Fruit2].Add(_fruit);
        }

        for (int i = 0; i < fruit3PoolCount; ++i)
        {
            GameObject _fruit = Instantiate(fruit3);
            _fruit.SetActive(false);
            _fruit.transform.SetParent(transform);

            fruitPool[(int)PoolFruitType.Fruit3].Add(_fruit);
        }

        for (int i = 0; i < fruitComboPoolCount; ++i)
        {
            GameObject _fruit = Instantiate(fruitCombo);
            _fruit.SetActive(false);
            _fruit.transform.SetParent(transform);

            fruitPool[(int)PoolFruitType.Fruit_Combo].Add(_fruit);
        }

        for (int i = 0; i < fruitSlowPoolCount; ++i)
        {
            GameObject _fruit = Instantiate(fruitSlow);
            _fruit.SetActive(false);
            _fruit.transform.SetParent(transform);

            fruitPool[(int)PoolFruitType.Fruit_Slow].Add(_fruit);
        }

        for (int i = 0; i < bombGameOverPoolCount; ++i)
        {
            GameObject _fruit = Instantiate(bombGameOver);
            _fruit.SetActive(false);
            _fruit.transform.SetParent(transform);

            fruitPool[(int)PoolFruitType.Bomb_GameOver].Add(_fruit);
        }

        for (int i = 0; i < bombDecTimePoolCount; ++i)
        {
            GameObject _fruit = Instantiate(bombDecTime);
            _fruit.SetActive(false);
            _fruit.transform.SetParent(transform);

            fruitPool[(int)PoolFruitType.Bomb_DecTime].Add(_fruit);
        }
    }

    public GameObject GetFruit(PoolFruitType _fruitType)
    {
        if (fruitPool[(int)_fruitType] == null)
        {
            return null;
        }

        for (int i = 0; i < fruitPool[(int)_fruitType].Count; ++i)
        {
            if (!fruitPool[(int)_fruitType][i].activeInHierarchy)
            {
                return fruitPool[(int)_fruitType][i];
            }
        }
        return null;
    }
}
