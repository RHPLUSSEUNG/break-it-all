using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveSliceFruit : Objective
{
    public int sliceToCompleteObjective = 50;

    public override bool IsAchieved()
    {
        return SpawnManager.Instance.sliceAllFruit >= sliceToCompleteObjective;
    }

    public override bool Completed()
    {
        Debug.Log("Slice Fruits Objective Completed");

        return true;
    }

    public override void Updated()
    {
        DisplayObjectiveManager.Instance.UpdateObjective(m_displayObjectiveLayout, SpawnManager.Instance.sliceAllFruit + "/" + sliceToCompleteObjective);
    }
}
