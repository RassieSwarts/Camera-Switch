using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float mouseSensitivity = 500f;//Variable for controlling the sensitivity of the mouse
    public Transform playerBody;//Variable for controlling the mouse look up and down without moving the playerbody
    
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;//Controls camera look and speed on mouse X axis, left and right
        //DataType variableName = Input(UnityAPI).GetAxis(left or right method)("Mouse X")(functionInput) *(Multiply) Time.deltaTime(Amount of time that went by since the
        //function Update() has been called)
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;//Controls camera look and speed on mouse Y axis, up and down

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90f);//Clamping the camera look as to not go and look behind the eyeballs/head

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
