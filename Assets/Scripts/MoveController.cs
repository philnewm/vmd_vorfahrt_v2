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
    [Tooltip("control the rotaion speed for mouse")] [SerializeField] float cSpeedMouse = 0.5f;
    [Tooltip("max rotation x-axis")] [SerializeField] float maxXRot = 35;
    [Tooltip("max rotation x-axis")] [SerializeField] float minXRot = -50;

    // Update is called once per frame
    void Update()
    {
        SetToLimit();
        ProcessRotationKeyboard();

        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            ProcessRotationMouse();
        }
    }

    private void SetToLimit()
    {
        if (xRot > maxXRot)
        {
            xRot = maxXRot;
        }
        else if(xRot < minXRot)
        {
            xRot = minXRot;
        }
        else
        {
            return;
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
        Debug.Log("xRot = " + xRot);
    }

    private void ProcessRotationMouse()
    {
        float yInput, xInput;

        yInput = CrossPlatformInputManager.GetAxis("Mouse X");
        yRot -= yInput * cSpeedMouse; //check if out of clamping range or just clamp it

        xInput = CrossPlatformInputManager.GetAxis("Mouse Y");
        xRot += xInput * cSpeedMouse;

        transform.localRotation = Quaternion.Euler(Mathf.Clamp(xRot, minXRot, maxXRot), yRot, 0);
        Debug.Log("xRot = " + xRot);
    }
}
