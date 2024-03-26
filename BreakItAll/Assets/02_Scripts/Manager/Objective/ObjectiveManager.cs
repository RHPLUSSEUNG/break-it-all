using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Instance;

    List<Objective> objectives = new List<Objective>();

    private void Awake()
    {
        Instance = this;

        Objective[] _objectvies = GetComponentsInChildren<Objective>();
        foreach(var item in _objectvies)
        {
            AddObjective(item);
        }
    }

    private void Update()
    {
        if(objectives.Count < 1)
        {
            return;
        }

        foreach (var objective in objectives)
        {
            if(objective.IsAchieved())
            {
                objective.Completed();
                Destroy(objective.gameObject);
                objectives.Remove(objective);
                break;
            }
        }
    }

    public void AddObjective(Objective _obj)
    {
        objectives.Add(_obj);
    }
}
