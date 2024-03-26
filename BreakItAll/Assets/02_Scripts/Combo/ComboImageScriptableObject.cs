using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Combo Image Data", menuName = "Scriptable Object/Combo Image Data", order = int.MaxValue)]

public class ComboImageScriptableObject : ScriptableObject
{
    [SerializeField] public Image[] comboImage;
}
