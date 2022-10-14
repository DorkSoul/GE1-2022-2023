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
    private float speed;
    private float ampHead;
    private float ampTail;
    private float currentRotation;
    private bool direction;
    

    // Start is called before the first frame update
    void Start()
    {
        theta = 0;
        direction = true;
            
        GameObject fish = GameObject.CreatePrimitive(PrimitiveType.Cube);
        fish.transform.position = new Vector3(0, 0, 0);
        fish.transform.localScale += new Vector3(1.0f, -0.0f, -0.0f);;
        fish.GetComponent<Renderer>().material.color = Color.HSVToRGB(0.9f,1.0f,1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        float headang = 0;
        float tailang = 0;
        theta+= Time.deltaTime * frequency;
        headang= Mathf.Sin(theta) * headAmplitude;
        tailang= Mathf.Sin(theta) * tailAmplitude;
        head.transform.localRotation = Quaternion.AngleAxis(headang,Vector3.forward ) ;

        tail.transform.localRotation = Quaternion.AngleAxis(tailang,Vector3.forward ); 
    }
}
