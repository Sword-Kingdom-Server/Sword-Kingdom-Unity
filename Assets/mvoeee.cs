using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour {
    GameObject Discoman;
    GameObject CameraControler;
    bool Isjumping = false;
    bool Jumpingcooldown = false;
    // Use this for initialization
    void Start () {
        Discoman = GameObject.Find("Discoman");
        CameraControler = GameObject.Find("Player camera pivot");
        Animator animationObj = Discoman.GetComponentInChildren<Animator>();
      
        animationObj.Play("Walking");
    }
	
	// Update is called once per frame
	void Update () {
 
        if (Input.GetKey(KeyCode.E))
        {
            if (GetPos(transform.eulerAngles.y) != GetPosition())
            {
                Turn(0);
            }
           // Vector3 front = new Vector3(0, GetPosition(), 0);
            transform.Translate(Vector3.forward * Time.deltaTime);
//            transform.eulerAngles = front;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (GetPos(transform.eulerAngles.y) != GetPosition() + 90)
            {
                Turn(90);
            }
             Vector3 left = new Vector3(0, GetPosition() + 90, 0);
            //transform.Translate(Vector3.forward * Time.deltaTime);
            transform.Translate(0, 0, 1);
           // transform.eulerAngles = left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (GetPos(transform.eulerAngles.y) != GetPosition() + 180)
            {
                Turn(180);
            }
            //Vector3 back = new Vector3(0, GetPosition() + 180, 0);
            transform.Translate(Vector3.forward * Time.deltaTime);
            //transform.Translate(Vector3.back * Time.deltaTime);
            //transform.eulerAngles = back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (GetPos(transform.eulerAngles.y) != GetPosition() + 270)
            {
                Turn(270);
            }
            //Vector3 right = new Vector3(0, GetPosition() + 270, 0);
            transform.Translate(Vector3.forward * Time.deltaTime);
            //transform.Translate(Vector3.right * Time.deltaTime);
            //transform.eulerAngles = right;

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Isjumping == false && Jumpingcooldown == false) {
            //transform.Translate(Vector3.up * 1);
            Discoman.GetComponent<Rigidbody>().AddForce(Vector3.up * 75);
                print("BLLLAARRGGGG");
            Isjumping = true;
            Jumpingcooldown = true;}
        }
        if (Input.GetKeyUp(KeyCode.Space)) { Jumpingcooldown = false; }



      //      if (Input.GetKey(KeyCode.LeftArrow))
       // {
        //        transform.Rotate(Vector3.down * Time.deltaTime * 10);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
         //   transform.Rotate(Vector3.up * Time.deltaTime * 10);
        //}

    }
    void OnCollisionStay()
    {
       // Isjumping = false;
    }

    public float GetPosition()
    {
    
        float R = CameraControler.transform.eulerAngles.y; ;
        //everything belowe here not commented out was added to trun this method into one that returns the rottion value of the camera as postiive
        if (Mathf.Sign(R) == -1)
        {
            float G = 360 + R;
            return G;
        }
        else { return R; }
        //this commented out code would make speicail consesccions if the degrees the camera was rotated at where negitive. turns out I didn't need it.
        //float N;
        //if (Mathf.Sign(R) == 1) {N = R + 180; }


        //the following commented out code was for inverting the degree of rotation, which it turns out I didn't need....
        //float N = R + 180;
        //if (N > 360)
        //{
         //   float G = N - 360;
          //  return G;
        //}
        //else
        //{
         //   return N;
        //}
    }

    public string GetTurnDirection(float A, float B)
    {
        //algorithm for finding the hortest turning directoin when chagning direction
        float A2;
        float B2;
        float N;
        if (Mathf.Sign(A) == -1)
        {
            A2 = 360 + A;

          N = B - A2;

         }
        else { N = B - A; }
        if (Mathf.Sign(N) == -1)
        { print("Neg!"); return "Neg"; }
        else { print("POS!"); return "Pos"; }

            if (Mathf.Sign(A) == -1) {
            A2 = 360 + A;
            if (Mathf.Sign(B) == -1)
            {
                B2 = 360 + B;
                N = A2 - B2;
            }
            else
            {
                N = A2 - B;
            }
        }
        if ((Mathf.Sign(B) == -1))
        {
            B2 = B + 180;
            N = A - B2;
        }
        else { N = A - B; }
        if (Mathf.Sign(N) == -1)
        {
            float N2 = Mathf.Abs(N);
            float R = 360 - N2;
            if (N2 > R) { print("Neg!"); return "Neg"; }
            else { print("POS!"); return "Pos"; }
        }
        else
        {
            float R = 360 - N;
            if (N > R) { print("Neg!"); return "Neg"; }
            else { print("POS!"); return "Pos"; }
        }
    }
    public float GetPos(float A)
    {
        if (Mathf.Sign(A) == -1)
        {
            float R = 360 + A;
              return R;
        }
        else { return A; }
    }

    public void Turn(float Direction)
    {
        float CurPos = GetPos(transform.eulerAngles.y);
        //float R = CameraControler.transform.eulerAngles.y;
        float Destination = GetPosition() + Direction;
        //Vector3 cross = Vector3.Cross(CurPos * Vector3.forward, CamPos * Vector3.forward);
        //float O = (CamPos - CurPos + 360) % 360;
        float rotSpeed = 5;                      //arbitrary speed of rotation

        float angleDiff = 180 - Mathf.Abs(Mathf.Abs(CurPos - Destination) - 180);            //find difference and wrap
        float angleDiffPlus = 180 - Mathf.Abs(Mathf.Abs((CurPos + rotSpeed) - Destination) - 180); //calculate effect of adding
        float angleDiffMinus = 180 - Mathf.Abs(Mathf.Abs((CurPos - rotSpeed) - Destination) - 180);
        if (angleDiffPlus < angleDiff)
        {        //if adding to ∠source reduces difference
            transform.Rotate(0, rotSpeed, 0);              //add to ∠source
        }
        else if (angleDiffMinus < angleDiff)
        { //if SUBTRACTING from ∠source reduces difference
            transform.Rotate(0, -rotSpeed, 0);               //subtract from ∠source
        }
        else
        {                                //if difference smaller than rotation speed
           // transform.Rotate(0, CamPos, 0);               //set ∠source to ∠destination
        }

//        if (GetTurnDirection(Y, GetPosition()) == "Neg")
 //       {
        //    if (Y > GetPosition())
       //     {
      //          if (Y - 5 < GetPosition())
     //           {
    //                float A = Y - GetPosition();
   //                 transform.Rotate(0, -A, 0);
  //              }
 //               else { transform.Rotate(0, -5, 0); }
//            }

   //         if (Y < GetPosition())
     //       {
                //do e need to subtract or add distance modifier?  should e correct for neggeitive? should it be 0 here instea of 360?
  //              if (Y - 5 <= 360)
   //             {
    //                float RE = 360 - Y;
     //               float RD = RE + GetPosition();
      //              if (RD < 5) { transform.Rotate(0, RD, 0); }
       //             if (RD == 5) { transform.Rotate(0, -5, 0); }
        //            if (RD > 5)
         //           {
          //              float D = RD / 5;
           //             int DR = (int)D;
            //            float S = 5 * DR;
             //           float RM = RD - S;
              //          while (D > 0)
           //             {
            //                transform.Rotate(0, -5, 0);
             //               D = D - 1;
              //          }
               //         if (D < 1) { transform.Rotate(0, -RM, 0); }
                //    }
                //}
            //                else { transform.Rotate(0, -5, 0); }
            //           }
   //         if (Y - 5 < GetPosition())
    //        {
     //           float A = Y - GetPosition();
      //          transform.Rotate(0, -A, 0);
       //     }
        //    else { transform.Rotate(0, -5, 0); }
        //}

   //     if (GetTurnDirection(Y, GetPosition()) == "Pos")
    //    {

//            if (Y < GetPosition())
 //           {
  //              if (Y + 5 > GetPosition())
   //             {
    //                float A = GetPosition() - Y;
     //               transform.Rotate(0, A, 0);
      //          }
       //         else { transform.Rotate(0, 5, 0); }
        //    }
         //   if (Y > GetPosition())
          //  {
                //do e need to subtract or add distance modifier?  should e correct for neggeitive?
     //           if (Y + 5 >= 360)
      //          {
       //             float RE = 360 - Y;
        //            float RD = RE + GetPosition();
         //           if (RD < 5) { transform.Rotate(0, RD, 0); }
          //          if (RD == 5) { transform.Rotate(0, 5, 0); }
           //         if (RD > 5)
            //        {
             //           float D = RD / 5;
              //          int DR = (int)D;
               //         float S = 5 * DR;
                //        float RM = RD - S;
                 //       while (D > 0)
                  //      {
                   //         transform.Rotate(0, 5, 0);
                    //        D = D - 1;
                     //   }
                      //  if (D < 1) { transform.Rotate(0, RM, 0); }
       //             }
        //        }
            //    else { transform.Rotate(0, 5, 0); }
            //}
       //     if (Y + 5 > GetPosition())
         //   {
          //      float A = GetPosition() - Y;
           //     transform.Rotate(0, A, 0);
            //}
       //     else { transform.Rotate(0, 5, 0); }
        //}
    }
}

