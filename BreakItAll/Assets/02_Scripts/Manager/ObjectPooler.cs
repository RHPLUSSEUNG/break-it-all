using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Good1,
    Good2,
    Good3,
    Bad1,
    Max_Size,
}

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    [Header("Good 1")]
    [SerializeField] GameObject good1Prefab;
    [SerializeField] int countObjectGood1;

    [Header("Good 2")]
    [SerializeField] GameObject good2Prefab;
    [SerializeField] int countObjectGood2;

    [Header("Good 3")]
    [SerializeField] GameObject good3Prefab;
    [SerializeField] int countObjectGood3;

    [Header("Bad 1")]
    [SerializeField] GameObject bad1Prefab;
    [SerializeField] int countObjectBad1;

    List<GameObject>[] objectPool = new List<GameObject>[(int)ObjectType.Max_Size];

    private void Awake()
    {
        Instance = this;

        objectPool[(int)ObjectType.Good1] = new List<GameObject>();
        objectPool[(int)ObjectType.Good2] = new List<GameObject>();
        objectPool[(int)ObjectType.Good3] = new List<GameObject>();
        objectPool[(int)ObjectType.Bad1] = new List<GameObject>();

        for (int i = 0; i < countObjectGood1; ++i)
        {
            GameObject _object = Instantiate(good1Prefab);
            _object.SetActive(false);
            _object.transform.SetParent(transform);

            objectPool[(int)ObjectType.Good1].Add(_object);
        }

        for (int i = 0; i < countObjectGood2; ++i)
        {
            GameObject _object = Instantiate(good2Prefab);
            _object.SetActive(false);
            _object.transform.SetParent(transform);

            objectPool[(int)ObjectType.Good2].Add(_object);
        }

        for (int i = 0; i < countObjectGood3; ++i)
        {
            GameObject _object = Instantiate(good3Prefab);
            _object.SetActive(false);
            _object.transform.SetParent(transform);

            objectPool[(int)ObjectType.Good3].Add(_object);
        }

        for (int i = 0; i < countObjectBad1; ++i)
        {
            GameObject _object = Instantiate(bad1Prefab);
            _object.SetActive(false);
            _object.transform.SetParent(transform);

            objectPool[(int)ObjectType.Bad1].Add(_object);
        }
    }

    public GameObject GetObject(ObjectType objectType)
    {
        if (objectPool[(int)objectType] == null)
        {
            return null;
        }


        for (int i = 0; i < objectPool[(int)objectType].Count; ++i)
        {
            if (!objectPool[(int)objectType][i].activeInHierarchy)
            {
                return objectPool[(int)objectType][i];
            }
        }
        return null;
    }
}
