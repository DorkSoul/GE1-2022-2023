using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRotate : MonoBehaviour
{
    public float rotationSpeed = 90.0f; // degrees per second
    public float attractionStrength = 15.0f; // strength of the attraction force
    public Material material;
    float currentHue = 0.0f;
    float minPitch = 0.5f;
    float maxPitch = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHue = 0.0f;
        minPitch = 0.5f;
        maxPitch = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSource otherAudioSource = other.GetComponent<AudioSource>();
        if (otherAudioSource != null)
        {
            otherAudioSource.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        float rotationDamping = 20.0f;

        // Check if the other object has a Rigidbody component
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Calculate the direction and distance to the center of the object
            Vector3 direction = transform.position - rb.transform.position;
            float distance = direction.magnitude;

                // Zero out y component of velocity and angular velocity
                rb.velocity = new Vector3(0, 0, 0);
                rb.angularVelocity = new Vector3(0, 0, 0);
                rb.useGravity = false;

                // Apply a force to the object to attract it towards the center
                Vector3 xForce = Vector3.Scale(direction.normalized, Vector3.right) * attractionStrength;
                Vector3 yForce = Vector3.Scale(direction.normalized, Vector3.up) * attractionStrength;
                Vector3 zForce = Vector3.Scale(direction.normalized, Vector3.forward) * attractionStrength;
                rb.AddForce(xForce);
                rb.AddForce(yForce);
                rb.AddForce(zForce);

            // Rotate the object around the Y axis at the specified speed
            rb.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            // Tend the rotation towards 0 on the x and z axis
            Quaternion targetRotation = Quaternion.Euler(0, rb.transform.rotation.eulerAngles.y, 0);
            rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, targetRotation, rotationDamping * Time.deltaTime);

            AudioSource otherAudioSource = other.GetComponent<AudioSource>();
            if (otherAudioSource != null)
            {
                // Calculate the target hue value based on the pitch of the current note
                float pitch = otherAudioSource.pitch;
                float minPitch = 0.5f; // adjust these values to set the pitch range
                float maxPitch = 20.0f;
                float targetHue = (pitch - minPitch) / (maxPitch - minPitch);

                // Interpolate between the current hue value and the target hue value using the Lerp function
                float lerpSpeed = 1.0f; // adjust this value to control the speed of the lerp
                currentHue = Mathf.Lerp(currentHue, targetHue, lerpSpeed);

                // Update the material color using the current hue value
                float saturation = 1.0f;
                float value = 1.0f;
                material.color = Color.HSVToRGB(currentHue, saturation, value);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the other object has an audioSource component
        AudioSource otherAudioSource = other.GetComponent<AudioSource>();
        if (otherAudioSource != null)
        {
            otherAudioSource.Stop();
        }
        
        // Check if the other object has a Rigidbody component
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Set useGravity to true when the trigger collider exits the trigger
            rb.useGravity = true;
        }
    }
}
