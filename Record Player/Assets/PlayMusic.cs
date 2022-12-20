using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public Material material;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Create an array to store the audio spectrum data
        float[] spectrumData = new float[1024];

        // Get the audio spectrum data from the AudioListener
        AudioListener.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

        // Calculate the average value of the spectrum data
        float averageValue = 0;
        for (int i = 0; i < spectrumData.Length; i++)
        {
            averageValue += spectrumData[i];
        }
        averageValue /= spectrumData.Length;

        // Use the average value to interpolate between 0 and 360 for the hue value
        float hue = Mathf.Lerp(0, 360, averageValue);

        // Set the saturation and value to constants
        float saturation = 1.0f;
        float value = 1.0f;

        // Use the Color.HSVToRGB method to convert the hue, saturation, and value to an RGB color
        Color color = Color.HSVToRGB(hue / 360.0f, saturation, value);

        // Apply the color to the object's material
        material.color = color;
    }
}
