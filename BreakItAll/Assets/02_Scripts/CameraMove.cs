using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform target;
    ComboMeshTrigger meshTrigger;
    Camera mainCamera;
    float orthograSize = 0;
    Vector3 cameraPos;

    [SerializeField] [Range(0.01f, 0.1f)] float shakeRange = 0.05f;
    [SerializeField] [Range(0.1f, 1f)] float duration = 0.5f;

    private void Awake()
    {
        mainCamera = Camera.main;
        mainCamera = GetComponent<Camera>();
        meshTrigger = GameObject.Find("ComboMeshTrigger").GetComponent<ComboMeshTrigger>();        
    }

    private void Update()
    {
        if(meshTrigger.targetInComboMesh)
        {
            orthograSize = Time.deltaTime * 10;
            mainCamera.orthographicSize -= orthograSize;            
            if(mainCamera.orthographicSize <= 1.5f)
            {
                mainCamera.orthographicSize = 1.5f;
                orthograSize = 0;
            }           
        }
        else if(!meshTrigger.targetInComboMesh)
        {
            orthograSize = Time.deltaTime * 10;
            mainCamera.orthographicSize += orthograSize;
            if(mainCamera.orthographicSize >= 5f)
            {
                mainCamera.orthographicSize = 5f;
                orthograSize = 0;
            }
        }
    } 

    public void Shake()
    {
        cameraPos = mainCamera.transform.position;
        InvokeRepeating("StartShake", 0f, 0.005f);
        Invoke("StopShake", duration);
    }

    void ReturnPosition()
    {
        transform.Translate(0, 5, -10);
    }

    void StartShake()
    {
        float camPosX = Random.value * shakeRange * 2 - shakeRange;
        float camPosY = Random.value * shakeRange * 2 - shakeRange;

        Vector3 cameraPos = mainCamera.transform.position;
        cameraPos.x += camPosX;
        cameraPos.y += camPosY;
        mainCamera.transform.position = cameraPos;
        

    }

    void StopShake()
    {
        CancelInvoke("StartShake");
        mainCamera.transform.position = new Vector3(0, 5, -10);
    }
}
