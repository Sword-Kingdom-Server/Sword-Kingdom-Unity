using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yawbiychay : MonoBehaviour {
    private GameObject CameraControler;
    private Vector3 offset;
    // Use this for initialization
    void Start()
    {
       
        CameraControler = GameObject.Find("Player camera pivot");
        offset = transform.position - CameraControler.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = CameraControler.transform.position + offset;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //            Quaternion originalRot = transform.rotation;
            //          transform.rotation = originalRot * Quaternion.AngleAxis(5, Vector3.up);
            float X = transform.eulerAngles.x;
            float Y = transform.eulerAngles.y;
            float Z = transform.eulerAngles.z;
            transform.eulerAngles = new Vector3(X, Y + 5, Z);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Quaternion originalRot = transform.rotation;
            // transform.Rotate(0, 5, 0);
            float X = transform.eulerAngles.x;
            float Y = transform.eulerAngles.y;
            float Z = transform.eulerAngles.z;
            transform.eulerAngles = new Vector3(X, Y - 5, Z);
        }
    }
}
