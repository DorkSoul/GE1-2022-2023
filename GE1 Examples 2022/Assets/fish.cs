using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish : MonoBehaviour
{
    public Transform head;
    public Transform tail;
    [Range(0.0f, 5.0f)]
    public float frequency = 0.5f;
    public float headAmplitude = 40;
    public float tailAmplitude = 60;

    public float theta = 0;

    // Start is called before the first frame update
    void Start()
    {
        theta = 0;
            
        GameObject fish = GameObject.CreatePrimitive(PrimitiveType.Cube);
        fish.transform.position = new Vector3(0, 0, 0);
        fish.transform.localScale += new Vector3(1.0f, -0.0f, -0.0f);;
        fish.GetComponent<Renderer>().material.color = Color.HSVToRGB(0.9f,1.0f,1.0f);
        fish.transform.parent = this.transform;

        GameObject head = GameObject.CreatePrimitive(PrimitiveType.Cube);
        head.transform.position = new Vector3(2.0f, 0, 0);
        head.transform.localScale += new Vector3(1.0f, -0.0f, -0.0f);;
        head.GetComponent<Renderer>().material.color = Color.HSVToRGB(0.9f,1.0f,1.0f);
        head.transform.parent = this.transform;

        GameObject tail = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tail.transform.position = new Vector3(-2.0f, 0, 0);
        tail.transform.localScale += new Vector3(1.0f, -0.0f, -0.0f);;
        tail.GetComponent<Renderer>().material.color = Color.HSVToRGB(0.9f,1.0f,1.0f);
        tail.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Your code goes here!

    }
}
