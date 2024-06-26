using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveByType : Objective
{
    public int sliceToCompleteObjective;

    public StuffType stuffType;

    public override bool IsAchieved()
    {
        return SpawnManager.Instance.sliceStuff[(int)stuffType] >= sliceToCompleteObjective;
    }

    public override bool Completed()
    {
        Debug.Log("Slice Stuffs Objective Completed");

        return true;
    }

    public override void Updated()
    {
        DisplayObjectiveManager.Instance.UpdateObjective(m_displayObjectiveLayout, SpawnManager.Instance.sliceStuff[(int)stuffType] + "/" + sliceToCompleteObjective);
    }
}
