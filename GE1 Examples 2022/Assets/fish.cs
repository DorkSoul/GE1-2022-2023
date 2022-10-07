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
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        theta = 0;
            
        GameObject fish = GameObject.CreatePrimitive(PrimitiveType.Cube);
        fish.transform.position = new Vector3(0, 0, 0);
        fish.transform.localScale += new Vector3(1.0f, -0.0f, -0.0f);;
        fish.GetComponent<Renderer>().material.color = Color.HSVToRGB(0.9f,1.0f,1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        z += Time.deltaTime * 75.0f;
        head.transform.localRotation = Quaternion.Euler(0, 0, z);
        tail.transform.localRotation = Quaternion.Euler(0, 0, -z);
        //head.transform.rotate(0, 30.0f, 0);
        //head.transform.Rotate(0, 30.0f, 0, Space.Self);
    }
}
