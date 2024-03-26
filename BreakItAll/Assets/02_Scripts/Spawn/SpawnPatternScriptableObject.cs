using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fruits Spawn Data", menuName = "Scriptable Object/Spawn Data", order = int.MaxValue)]

public class SpawnPatternScriptableObject : ScriptableObject
{
    [SerializeField] public SpawnPattern[] spawnPattern;

    [System.Serializable]
    public struct SpawnElementData
    {
        [SerializeField] public PoolFruitType fruitType;
        [SerializeField] public float spawnTime;
        [SerializeField] public float forceFactor;
        [SerializeField] public Vector3 spawnPosition;        
    }

    [System.Serializable]
    public struct SpawnPattern
    {
        [SerializeField] public float patternTimer;
        [SerializeField] public SpawnElementData[] spawnElementData;        
    }
}