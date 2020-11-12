using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class ZoomControl : MonoBehaviour
{
    //member variables
    Controls controls;
    float zoom;
    Mouse mouse;
    Touch touch1, touch2;


    //params
    [SerializeField] float zoomSpeed = 1/120f;

    private void Awake()
    {
        controls = new Controls();

        controls.CameraController.ZoomMouse.performed += cntxt => zoom = cntxt.ReadValue<float>();
        controls.CameraController.ZoomMouse.canceled += cntxt => zoom = float.NaN;

        mouse = Mouse.current;
    }

    private void Update()
    {
       // SetToLimit();
      if(zoom != 0.0f)
        {
            MouseZoom();
        }
    }

    private void MouseZoom()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.parent.position, zoom * zoomSpeed );
        Debug.Log(zoom);
    }

    //private void SetToLimit()
    //{
    //    if (currentRotation.x > maxXRot)
    //    {
    //        currentRotation.x = maxXRot;
    //    }
    //    else if (currentRotation.x < minXRot)
    //    {
    //        currentRotation.x = minXRot;
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}

    private void OnEnable()
    {
        controls.CameraController.Enable();
    }

    private void OnDisable()
    {
        controls.CameraController.Disable();
    }
}
