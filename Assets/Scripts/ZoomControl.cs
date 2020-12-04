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
    float sliderZoom;


    //params
    [Header("Mouse Scroll Zoom")]
    [SerializeField] float zoomSpeed;
    [SerializeField] float maxZoom;
    [SerializeField] float minZoom;

    [Header("Slider Zoom")]
    [SerializeField] float defaultFOV = 25;
    [SerializeField] float multFOV = 2;
    [SerializeField] float multScale = 1;
    [SerializeField] Vector3 defaultScale;
    [SerializeField] float curScale;

   [Header("Camera Reference")]
    [SerializeField] Camera camera;

    private void Awake()
    {
        defaultScale = gameObject.transform.localScale;
    }

    public void OnMouseZoom(InputAction.CallbackContext value)
    {
        SetToLimit();
        curScale = defaultScale.x;
        float inputScale = value.ReadValue<float>();

        float zoomControl = inputScale * zoomSpeed;
        curScale += zoomControl;
        gameObject.transform.localScale = new Vector3(Mathf.Clamp(curScale, minZoom, maxZoom), 
                                                      Mathf.Clamp(curScale, minZoom, maxZoom),
                                                      Mathf.Clamp(curScale, minZoom, maxZoom));
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

    public void SliderZoom(float zoomValue)
    {
        curScale = defaultScale.x;
        float newZoom = curScale + (zoomValue * zoomValue * multScale);

        gameObject.transform.localScale = new Vector3(newZoom, newZoom, newZoom);
        camera.fieldOfView = defaultFOV + (multFOV * zoomValue);
    }
}
