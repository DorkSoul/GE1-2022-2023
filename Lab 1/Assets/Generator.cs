﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int loops = 10;
    public GameObject dodec;
    // Start is called before the first frame update
    void Start()
    {
        int rad = 1;
        for(int i = 1 ; i <= loops ; i ++)
        {
            int numdodecs = (int)(1.0f * Mathf.PI * i * rad);
            float theta = Mathf.PI * 2.0f / ((float)numdodecs);
            for (int j = 0 ; j < numdodecs ; j ++)
            {
                float angle  = j * theta; 
                float x = Mathf.Sin(angle) * rad * (i) * 1.1f;
                float y = Mathf.Cos(angle) * rad * (i) * 1.1f;
                GameObject g = GameObject.Instantiate<GameObject>(dodec);
                g.transform.position = new Vector3(x, y, 0);
                g.GetComponent<Renderer>().material.color =
                    Color.HSVToRGB(j / (float) numdodecs, 1, 1);
                g.transform.parent = this.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
