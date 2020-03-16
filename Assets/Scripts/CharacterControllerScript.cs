using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    CharacterController cc;

    public float upRecoil;
    public float sideRecoil;

    //rotation angles
    public float xAngle;
    public float yAngle;
    public float xTempAngle;
    public float yTempAngle;

    //start and end positions of touches
    public Vector3 FirstPosition;
    public Vector3 secondPosition;
    //input variables
    public Vector2 threshold = new Vector2(-0.2f, 0.2f);

    //rotation values
    public float Rot_X;
    public float Rot_Y;

    public float speed = 10f;
    public float moveSpeed = 2f;
    //clamping rotation values
    public Vector2 clampX = new Vector2(-30 , 30);
    public Vector2 clampY = new Vector2(-30, 30);

    Transform CameraTransform;
    Quaternion OriginalRotation;
    //public Joystick joyStick;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        CameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        OriginalRotation = CameraTransform.rotation;
        upRecoil = 0f;
        sideRecoil = 0f;
        xAngle = 0f;
        yAngle = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        RotatePlayer();
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }

    void RotatePlayer()
    {
        if(Input.touchCount > 0)
        {
            //touch began
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                FirstPosition = Input.GetTouch(0).position;
                xTempAngle = xAngle;
                yTempAngle = yAngle;
            }
            
            // touch moved
            if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                secondPosition = Input.GetTouch(0).position;

                yAngle = yTempAngle - (secondPosition.y - FirstPosition.y) * 180f / Screen.height;
                if(yAngle < -30)
                {
                    yAngle = 330;
                }
                if(yAngle > 30)
                {
                    yAngle = 30;
                }

                if (yAngle > 30 && yAngle < 330)
                {
                    xAngle = xTempAngle - (secondPosition.x - FirstPosition.x) * 90f / Screen.width;
                }
                else
                {
                    xAngle = xTempAngle + (secondPosition.x - FirstPosition.x) * 90f / Screen.width;
                }

                if(xAngle < -30)
                {
                    xAngle = 330;
                }
                if(xAngle > 30)
                {
                    xAngle = 30;
                }
                xAngle += sideRecoil;
                yAngle += upRecoil;
                CameraTransform.rotation = Quaternion.Euler(yAngle, xAngle, 0);
            }
        }
        //when user is not touching the screen 
        else
        {
            CameraTransform.rotation = Quaternion.Lerp(CameraTransform.rotation, OriginalRotation, Time.time * speed);
        }

        ////////////////////////////////////////////////////////
        //// resetting the camera rotation if joystick is free
        //if((joyStick.Horizontal <= threshold.y && joyStick.Horizontal >= threshold.x) &&( joyStick.Vertical <= threshold.y && joyStick.Vertical >= threshold.x))
        //{
        //    CameraTransform.rotation = Quaternion.Lerp(CameraTransform.rotation, OriginalRotation, Time.time * speed);
        //}

        //// horizontal rotation
        //if(joyStick.Horizontal >= threshold.y)
        //{
        //    Rot_X = joyStick.Horizontal * 360;
        //}
        //else if(joyStick.Horizontal <= threshold.x)
        //{
        //    Rot_X = 360 + joyStick.Horizontal * 360;
        //}

        //// vertical rotation
        //if(joyStick.Vertical >= threshold.y)
        //{
        //    Rot_Y = joyStick.Vertical * 360;
        //}
        //else if(joyStick.Vertical <= threshold.x)
        //{
        //    Rot_Y = 360 + joyStick.Vertical * 360;
        //}

        //// clamping the rotation values
        //if(Rot_X <= clampX.x)
        //{
        //    Rot_X = 360 + clampX.x;
        //}
        //else if(Rot_X >= clampX.y)
        //{
        //    Rot_X = clampX.y;
        //}

        //if(Rot_Y <= clampY.x)
        //{
        //    Rot_Y = 360 + clampY.x;
        //}
        //else if(Rot_Y >= clampY.y)
        //{
        //    Rot_Y = clampY.y;
        //}

        //Vector3 cameraRotation = CameraTransform.rotation.eulerAngles;

        //cameraRotation.x = Rot_X + sideRecoil;
        //sideRecoil = 0;
        //cameraRotation.y = Rot_Y + upRecoil;
        //upRecoil = 0;
        //cameraRotation.z = 0;

        //CameraTransform.rotation = Quaternion.Euler(cameraRotation);
    }
}
