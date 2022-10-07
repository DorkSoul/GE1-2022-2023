using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject head = GameObject.CreatePrimitive(PrimitiveType.Cube);
        head.transform.position = new Vector3(-2.0f, 0, 0);
        head.transform.localScale += new Vector3(1.0f, -0.0f, -0.0f);;
        head.GetComponent<Renderer>().material.color = Color.HSVToRGB(0.9f,1.0f,1.0f); 
        head.transform.parent = this.transform;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
