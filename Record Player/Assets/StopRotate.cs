using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRotate : MonoBehaviour
{
    public float rotationSpeed = 90.0f; // degrees per second
    public float attractionStrength = 15.0f; // strength of the attraction force
    public Material material;
    public GameObject childParticleSystem;
    private float timer = 0.0f;
    private float counter = 0;
    private float hue = 0.0f;
    private float oldHue = 0.0f;
    private float newHue = 0.0f;
    private float fps = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Set the child GameObject
        childParticleSystem = transform.GetChild(0).gameObject;

        // Use the Color.HSVToRGB method to convert the hue, saturation, and value to an RGB color
        Color color = Color.HSVToRGB(0.5f, 1.0f, 1.0f);

        // Use the Color constructor to create a new color with the RGB values from the HSV color and the alpha value
        Color transparentColor = new Color(color.r, color.g, color.b, 0.5f);
        
        // Apply the transparent color to the object's material
        material.color = transparentColor;
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
        float saturation = 1.0f;
        float value = 1.0f;

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

            // Increment the timer by the time since the last frame
            timer += Time.deltaTime;

            // If the timer has reached 1 second (or greater)
            if (timer >= 1.0f)
            {
                counter = 0;
                // Reset the timer
                timer = 0.0f;

                oldHue = hue;

                float[] smoothedSpectrumData = new float[1024];

                // Create an array to store the audio spectrum data
                float[] spectrumData = new float[1024];

                // Get the audio spectrum data from the AudioListener
                AudioListener.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

                for (int i = 0; i < spectrumData.Length; i++)
                {
                    smoothedSpectrumData[i] = spectrumData[i];
                }

                for (int i = 1; i < smoothedSpectrumData.Length - 1; i++)
                {
                    smoothedSpectrumData[i] = (smoothedSpectrumData[i - 1] + smoothedSpectrumData[i] + smoothedSpectrumData[i + 1]) / 3;
                }

                // Calculate the average value of the spectrum data
                float averageValue = 0;
                for (int i = 0; i < smoothedSpectrumData.Length; i++)
                {
                    averageValue += smoothedSpectrumData[i];
                }
                averageValue /= smoothedSpectrumData.Length;

                // Use the average value to interpolate between 0 and 360 for the hue value
                hue = Mathf.Lerp(0, 1, (averageValue*100));
                newHue = hue;
            }

            fps = 1 / Time.deltaTime;
            counter = counter+1;

            newHue = Mathf.Lerp(oldHue, hue, counter/fps);            

            Color color = Color.HSVToRGB(newHue, saturation, value);

            // Set the alpha value to a constant
            float alpha = 0.5f;

            // Use the Color constructor to create a new color with the RGB values from the HSV color and the alpha value
            Color transparentColor = new Color(color.r, color.g, color.b, alpha);

            // Apply the transparent color to the object's material
            material.color = transparentColor;                
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
