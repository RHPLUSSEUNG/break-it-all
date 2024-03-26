using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public struct DisplayObjectiveMessage
{
    public string _TitileText;
    public string _DescriptionText;
    public string _CounterText;
}

public class DisplayObjectiveLayout : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TitleText;
    [SerializeField] TextMeshProUGUI m_DescriptionText;
    [SerializeField] TextMeshProUGUI m_CounterText;
    [SerializeField] Image m_StatusImage;

    public void InitializeObjective(DisplayObjectiveMessage _display)
    {
        m_TitleText.text = _display._TitileText;
        m_DescriptionText.text = _display._DescriptionText;
        m_CounterText.text = _display._CounterText;
    }

    public void UpdateCounter(string _counterText)
    {
        m_CounterText.text = _counterText;
    }

    public void UpdateCompleted()
    {
        m_StatusImage.color = Color.green;
        m_CounterText.color = Color.green;
        m_DescriptionText.color = Color.green;
    }
}
