using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveSliceStuff : Objective
{
    public int sliceToCompleteObjective = 50;

    public override bool IsAchieved()
    {
        return SpawnManager.Instance.sliceAllStuff >= sliceToCompleteObjective;
    }

    public override bool Completed()
    {
        Debug.Log("Slice Stuffs Objective Completed");

        return true;
    }

    public override void Updated()
    {
        DisplayObjectiveManager.Instance.UpdateObjective(m_displayObjectiveLayout, SpawnManager.Instance.sliceAllStuff + "/" + sliceToCompleteObjective);
    }
}
