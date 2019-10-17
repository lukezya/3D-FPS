using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity;

    //clamping rotation of player
    float xAxisClamp = 0.0f;

    void Awake()
    {
        //take cursor off of screen but keep cursor within screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //check mouse movement rotation
        RotateCamera();       
    }

    void RotateCamera()
    {
        //get mouse movements
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        //change rotation of camera and avatar body
        xAxisClamp -= rotAmountY;

        Vector3 targetRotCam = transform.rotation.eulerAngles;
        Vector3 targetRotBody = playerBody.rotation.eulerAngles;

        targetRotCam.x -= rotAmountY;
        targetRotCam.z = 0;
        targetRotBody.y += rotAmountX;

        //clamp rotation axis
        if(xAxisClamp > 90)
        {
            xAxisClamp = 90;
            targetRotCam.x = 90;
        }
        else if(xAxisClamp < -90)
        {
            xAxisClamp = -90;
            targetRotCam.x = 270;
        }

        //print(mouseY);


        transform.rotation = Quaternion.Euler(targetRotCam);
        playerBody.rotation = Quaternion.Euler(targetRotBody);


    }



}
