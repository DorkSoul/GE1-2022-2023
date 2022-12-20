using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    public int numrecs = 7;
    public GameObject RecordPrefab;
    public AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        float rad = 0.7f;
            
        float theta = Mathf.PI * 2.0f / ((float)numrecs);
        for (int j = 0 ; j < numrecs ; j ++)
        {
            float angle  = j * theta; 
            float x = Mathf.Sin(angle) * (rad) * 1.1f;
            float z = Mathf.Cos(angle) * (rad) * 1.1f;
            GameObject record = GameObject.Instantiate<GameObject>(RecordPrefab);
            record.transform.position = transform.TransformPoint(new Vector3(x, 0, z));
            Transform label = record.transform.GetChild(0);
            label.GetComponent<Renderer>().material.color =
                Color.HSVToRGB(j / (float) numrecs, 1, 1);
            record.transform.parent = this.transform;

            record.AddComponent<AudioSource>();
            AudioSource audioSource = record.GetComponent<AudioSource>();
            audioSource.clip = audioClips[j];;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
