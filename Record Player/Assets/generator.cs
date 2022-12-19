using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    public int loops = 10;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        int rad = 1;
        for(int i = 1 ; i <= loops ; i ++)
        {
            int numrecs = 10;
            float theta = Mathf.PI * 2.0f / ((float)numrecs);

            float angle  = 5 * theta; 
            float x = Mathf.Sin(angle) * rad * (i) * 1.1f;
            float y = Mathf.Cos(angle) * rad * (i) * 1.1f;
            GameObject g = GameObject.Instantiate<GameObject>(prefab);
            g.transform.position = transform.TransformPoint(new Vector3(x,y, 0));
            g.transform.parent = this.transform;
            // g.transform.position = new Vector3(x, y, 0);
            // g.GetComponent<Renderer>().material.color =
            //     Color.HSVToRGB(i / (float) numrecs, 1, 1);
            // g.transform.parent = this.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
