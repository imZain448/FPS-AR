using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    CharacterController cc;

    

    //input variables
    public float X_input;
    public float Y_input;

    //rotation values
    public float Rot_X;
    public float Rot_Y;

    public float speed = 10f;
    public float moveSpeed = 2f;
    //clamping rotation values
    float clampX = 0;
    float clampY = 0;

    Transform CameraTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        CameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        RotatePlayer();
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }

    void RotatePlayer()
    {
        Y_input = Input.GetAxis("Mouse Y");
        X_input = Input.GetAxis("Mouse X");

        Rot_X = X_input * speed;
        Rot_Y = Y_input * speed;

        clampX += Rot_Y;
        clampY += Rot_X;

        Vector3 CameraRotation = CameraTransform.transform.rotation.eulerAngles;
        
        CameraRotation.x += Rot_Y;
        CameraRotation.y += Rot_X;
        CameraRotation.z = 0;

        if(clampX <= -20)
        {
            clampX = -20;
            CameraRotation.x = 340;
        }
        else if(clampX >= 20)
        {
            clampX = 20;
            CameraRotation.x = 20;
        }

        if(clampY <= -30)
        {
            clampY = -30;
            CameraRotation.y = 330;
        }
        else if(clampY >= 30)
        {
            clampY = 30;
            CameraRotation.y = 30;
        }

        CameraTransform.rotation = Quaternion.Euler(CameraRotation);

    }
}
