using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int width = 5, height = 10;
    // Start is called before the first frame update
    void Start()
    {
        for(int j = 0 ; j < height ; j ++){

            for(int i = 0 ; i < width ; i ++){
               GameObject room = GameObject.CreatePrimitive(PrimitiveType.Cube);
               room.transform.position = transform.TransformPoint(new Vector3(i, -0.5f, j));
               room.GetComponent<Renderer>().material.color = 
                    Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1.0f, 1.0f);
                room.transform.parent = this.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
