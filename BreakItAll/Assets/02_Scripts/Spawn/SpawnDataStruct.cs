using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public struct SpawnElementData
{    
    [SerializeField] public float spawnTime;
    [SerializeField] public float forceFactor;
    [SerializeField] public Vector3 spawnPosition;
    [SerializeField] public PoolFruitType fruitType;
}

[System.Serializable] public struct SpawnPattern
{
    [SerializeField] public SpawnElementData[] spawnElementData;    
}

public class SpawnDataStruct : MonoBehaviour
{
   
}
