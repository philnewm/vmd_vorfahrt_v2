using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveController : MonoBehaviour
{
    //member variables
    

    //params
    [Tooltip("horizontal rotation")] [SerializeField] float xRot = 0;
    [Tooltip("vertcial rotation")] [SerializeField] float yRot;
    [Tooltip("control the rotaion speed on y-axis")] [SerializeField] float cSpeedY = 0.5f;
    [Tooltip("control the rotaion speed on x-axis")] [SerializeField] float cSpeedX = 0.5f;
    [Tooltip("control the rotaion speed for mouse")] [SerializeField] float cSpeedMouse = 0.1f;
    [Tooltip("max rotation x-axis")] [SerializeField] float maxXRot = -50;
    [Tooltip("max rotation x-axis")] [SerializeField] float minXRot = 35;

    // Update is called once per frame
    void Update()
    {
        ProcessRotationKeyboard();

        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            ProcessRotationMouse();
        }
    }

    private void ProcessRotationKeyboard()
    {
        float yInput, xInput;

        yInput = CrossPlatformInputManager.GetAxis("Horizontal");
        yRot += yInput * cSpeedY;

        xInput = CrossPlatformInputManager.GetAxis("Vertical");
        xRot += xInput * cSpeedX;

        transform.localRotation = Quaternion.Euler(Mathf.Clamp(xRot, minXRot, maxXRot), yRot, 0);

        Debug.Log("yRot = " + yRot);
        Debug.Log("xRot = " + xRot);
    }

    private void ProcessRotationMouse()
    {
        float yInput, xInput;

        yInput = CrossPlatformInputManager.GetAxis("Mouse X");
        yRot -= yInput * cSpeedMouse;

        xInput = CrossPlatformInputManager.GetAxis("Mouse Y");
        xRot += xInput * cSpeedMouse;

        transform.localRotation = Quaternion.Euler(Mathf.Clamp(xRot, minXRot, maxXRot), yRot, 0);

        Debug.Log("yRot = " + yRot);
        Debug.Log("xRot = " + xRot);
    }
}
