using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRotate : MonoBehaviour
{
    public float rotationSpeed = 90.0f; // degrees per second
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
{
    // Check if the other object has a Rigidbody component
    Rigidbody rb = other.GetComponent<Rigidbody>();
    if (rb != null)
    {
        // Rotate the object around the Y axis at the specified speed
        rb.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}
}
