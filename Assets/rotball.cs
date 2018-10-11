using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotball : MonoBehaviour {
    private GameObject CameraControler;
    private Vector3 offset;
    // Use this for initialization
    void Start () {
        CameraControler = GameObject.Find("Player camera pivot");
        offset = transform.position - CameraControler.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = CameraControler.transform.position + offset;
       
    }
        
}
