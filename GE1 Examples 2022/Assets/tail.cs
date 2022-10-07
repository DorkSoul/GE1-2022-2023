using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject tail = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tail.transform.position = new Vector3(2.0f, 0, 0);
        tail.transform.localScale += new Vector3(1.0f, -0.0f, -0.0f);;
        tail.GetComponent<Renderer>().material.color = Color.HSVToRGB(0.9f,1.0f,1.0f);  
        tail.transform.parent = this.transform;   
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
