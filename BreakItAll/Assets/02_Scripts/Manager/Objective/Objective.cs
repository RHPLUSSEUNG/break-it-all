using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectiveType
{
    SliceFruit,
    ModeCount,
}

public abstract class  Objective : MonoBehaviour
{
    public uint uid;
    public ObjectiveType objectiveType;
    public string Title;
    public string Description;

    protected DisplayObjectiveMessage m_displayObjective;
    protected GameObject m_displayObjectiveLayout;

    public abstract bool IsAchieved();

    public abstract bool Completed();

    public abstract void Updated();

}
