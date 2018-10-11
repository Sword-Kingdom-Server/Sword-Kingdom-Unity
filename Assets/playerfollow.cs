using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerfollow : MonoBehaviour {
    private Vector3 offset;
    public GameObject Discoman;
    GameObject CameraControler;
    // Use this for initialization
    void Start () {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        Discoman = GameObject.Find("Discoman");
        CameraControler = GameObject.Find("Player camera pivot");
        offset = transform.position - Discoman.transform.position;
       
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Discoman.transform.position + offset;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //            Quaternion originalRot = transform.rotation;
            //          transform.rotation = originalRot * Quaternion.AngleAxis(5, Vector3.up);
            float X = transform.eulerAngles.x;
            float Y = transform.eulerAngles.y;
            float Z = transform.eulerAngles.z;
            transform.eulerAngles = new Vector3(X, Y + 5, Z);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            //Quaternion originalRot = transform.rotation;
            // transform.Rotate(0, 5, 0);
            float X = transform.eulerAngles.x;
            float Y = transform.eulerAngles.y;
            float Z = transform.eulerAngles.z;
            transform.eulerAngles = new Vector3(X, Y - 5, Z);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Quaternion Q = CameraControler.transform.rotation;
            //Vector3 E = Q.eulerAngles;
            //float R = E.x;
            float N = ReturnPositive(transform.eulerAngles.x);
            if (N < 90 && N + 5 < 90 || N > 299)
            {
                float X = transform.eulerAngles.x;
                float Y = transform.eulerAngles.y;
                float Z = transform.eulerAngles.z;
                transform.eulerAngles = new Vector3(X + 5, Y, Z);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Quaternion Q = CameraControler.transform.rotation;
            //Vector3 E = Q.eulerAngles;
            //float R = E.x;
            float N = ReturnPositive(transform.eulerAngles.x);
            if (N > 299 && N - 5 > 299 || N < 90)
            {
                float X = transform.eulerAngles.x;
                float Y = transform.eulerAngles.y;
                float Z = transform.eulerAngles.z;
                transform.eulerAngles = new Vector3(X - 5, Y, Z);
            }
        }
    }

    private float ReturnPositive(float N)
    {
        if (Mathf.Sign(N) == -1)
        {
            float R = 360 + N;
            return R;
        }
        else { return N; }
    }
}
