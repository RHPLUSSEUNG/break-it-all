using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    ScoreManager scoreManager;
    Blade blade;

    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] GameObject comboTextPivot;

    Vector3 coPos;

    [SerializeField] int comboCount;
    int comboScore;
    float comboTimer;
    float comboLimitTime = .3f;

    List<GameObject> comboList = new List<GameObject>();

    private void Start()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        comboCount = 0;
        comboTimer = 0;
        comboScore = 0;
        comboList.Clear();

    }

    private void Update()
    {
        isCombo();
        Debug.Log(comboTimer);
    }

    public void coPosSet(Vector3 pos)
    {
        coPos = pos;
    }

    public void AddComboList(GameObject _comboCount)
    {
        comboList.Add(_comboCount);
        comboCount = comboList.Count;
        comboTimer = 0;
        comboScore += _comboCount.GetComponent<Fruit>().pointValue;
    }

    public void isCombo()
    {
        switch (comboCount)
        {
            case 1:
                comboTimer += Time.deltaTime;
                break;
            case 2:
                comboTimer += Time.deltaTime;
                break;
            case 3:
                comboTimer += Time.deltaTime;
                break;
            case 4:
                comboTimer += Time.deltaTime;
                break;
            case 5:
                comboTimer += Time.deltaTime;
                break;
            case 6:
                comboTimer += Time.deltaTime;
                break;
            case 7:
                comboTimer += Time.deltaTime;
                break;
            case 8:
                comboTimer += Time.deltaTime;
                break;
            case 9:
                comboTimer += Time.deltaTime;
                break;
            case 10:
                comboTimer += Time.deltaTime;
                break;
            default:
                break;
        }

        if (comboCount >= 3 && comboLimitTime < comboTimer)
        {
            int _comboCount = comboCount - 3;

            comboText.text = "Combo! " + comboCount.ToString();
            Instantiate(comboText, coPos, Quaternion.identity, comboTextPivot.transform);

            scoreManager.UpdateScore(comboScore);
            comboTimer = 0;
            comboCount = 0;
            comboScore = 0;
            comboList.Clear();
        }
        else if (comboCount < 3 && comboLimitTime < comboTimer)
        {
            comboTimer = 0;
            comboCount = 0;
            comboList.Clear();
            comboScore = 0;
        }

    }

}
