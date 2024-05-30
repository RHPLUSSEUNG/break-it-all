using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboMeshTrigger : MonoBehaviour
{
    public bool targetInComboMesh;

    public void SetTargetInComboMesh(bool _targetIn)
    {
        targetInComboMesh = _targetIn;
    }

    private void OnTriggerStay(Collider other)
    {      
        other.gameObject.GetComponent<Stuff>();

        if (other.gameObject.GetComponent<Stuff>().stuffType == StuffType.Combo)
        {
            other.transform.position = this.transform.position;
            targetInComboMesh = true;                        
        }        
    }
}
