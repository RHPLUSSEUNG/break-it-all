using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpFunction : MonoBehaviour
{
    public bool isApply;
    [SerializeField] Image checkImg;
    private void Start()
    {
        isApply = false;        
    }

    private void Update()
    {
        if(isApply)
        {
            checkImg.gameObject.SetActive(true);
        }
    }

    public void IsApply()
    {
        isApply = true;
    }
}
