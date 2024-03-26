using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeImageFunction : MonoBehaviour
{
    float time = 0;
    float _size = 1.2f;
    float _upSizeTime = 0.5f;

    private void Update()
    {
        if (time <= _upSizeTime)
        {
            transform.localScale = Vector3.one * (1 + _size * time);
        }
        else if (time <= _upSizeTime * 4)
        {
            transform.localScale = Vector3.one * (2 * _size * _upSizeTime + 1 - time * _size);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
        if (2 * _size * _upSizeTime + 1 - time * _size < 0)
        {
            Destroy(gameObject);
        }
        time += Time.deltaTime;
    }
}
