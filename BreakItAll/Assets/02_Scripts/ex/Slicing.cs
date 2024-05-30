using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicing : MonoBehaviour
{
    [SerializeField] GameObject whole;
    [SerializeField] GameObject sliced;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    private Rigidbody stuffRigidbody;
    private Collider stuffCollider;
    private void Awake()
    {
        stuffRigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        stuffRigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        stuffRigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    void Slice(Vector3 direction, Vector3 position, float force)
    {
        whole.SetActive(false);
        whole.SetActive(true);

        stuffCollider.enabled = false;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody slice in slices)
        {
            slice.velocity = stuffRigidbody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Blade blade = other.GetComponent<Blade>();
          //  Slice(blade.direction, blade.transform.position, blade.sliceForce);
        }
    }

}
