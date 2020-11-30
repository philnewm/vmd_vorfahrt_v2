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
    Vector3 zoomVector;
    float curScale = 1;


    //params
    [SerializeField] float zoomSpeed;
    [SerializeField] float maxZoom;
    [SerializeField] float minZoom;

    private void Awake()
    {
        controls = new Controls();

        controls.CameraController.ZoomMouse.performed += cntxt => zoom = cntxt.ReadValue<float>()/ 120f;
        controls.CameraController.ZoomMouse.canceled += cntxt => zoom = float.NaN;
    }

    private void Update()
    {
        SetToLimit();

        if (zoom != 0)
        {
            MouseZoom();
        }
    }

    private void MouseZoom()
    {
        float zoomControl = zoom * zoomSpeed;
        curScale += zoomControl;
        gameObject.transform.localScale = new Vector3(Mathf.Clamp(curScale, minZoom, maxZoom), 
                                                      Mathf.Clamp(curScale, minZoom, maxZoom),
                                                      Mathf.Clamp(curScale, minZoom, maxZoom));
    }

    private void OnEnable()
    {
        controls.CameraController.Enable();
    }

    private void OnDisable()
    {
        controls.CameraController.Disable();
    }
    private void SetToLimit()
    {
        if (curScale > maxZoom)
        {
            curScale = maxZoom;
        }
        else if (curScale < minZoom)
        {
            curScale = minZoom;
        }
        else
        {
            return;
        }
    }
}
