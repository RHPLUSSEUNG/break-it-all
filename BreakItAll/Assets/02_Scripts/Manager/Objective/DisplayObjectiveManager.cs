using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayObjectiveManager : MonoBehaviour
{
    public static DisplayObjectiveManager Instance;

    [SerializeField] GameObject objectiveUIPrefab;

    List<GameObject> m_ObjectiveList;

    private void Awake()
    {
        Instance = this;
        m_ObjectiveList = new List<GameObject>();
    }

    public GameObject RegisterObjective(DisplayObjectiveMessage _display)
    {
        GameObject newObjective = Instantiate(objectiveUIPrefab);
        newObjective.GetComponent<DisplayObjectiveLayout>().InitializeObjective(_display);
        newObjective.transform.SetParent(this.transform);
        m_ObjectiveList.Add(newObjective);

        return newObjective;
    }

    public void UpdateObjective(GameObject _obj, string _CounterText, bool isCompleted = false)
    {
        if (_obj == null)
            return;

        _obj.GetComponent<DisplayObjectiveLayout>().UpdateCounter(_CounterText);

        if (isCompleted == true)
            _obj.GetComponent<DisplayObjectiveLayout>().UpdateCompleted();
    }

    public void UnregisterAllObjectives()
    {
        foreach(var item in m_ObjectiveList)
        {
            Destroy(item);
        }
        m_ObjectiveList.Clear();
    }
}
