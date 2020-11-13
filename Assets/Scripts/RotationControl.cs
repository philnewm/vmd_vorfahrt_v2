using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotationControl : MonoBehaviour
{
    //member variables
    Controls controls;
    Vector2 rot;
    Vector3 rotation;
    Vector3 currentRotation;
    Quaternion defaultRotation;

    //params
    [SerializeField] float moveSpeed = 0.3f;
    [SerializeField] float minXRot = -25f;
    [SerializeField] float maxXRot = 35f;
    [SerializeField] float smoothSpeed = 5.0f;

    private void Awake()
    {
        defaultRotation = gameObject.transform.rotation;

        controls = new Controls();

        controls.CameraController.RotationControl.performed += cntxt => rot = cntxt.ReadValue<Vector2>();
        controls.CameraController.RotationControl.canceled += cntxt => rot = Vector2.zero;
    }

    private void Update()
    {
        SetToLimit();
        MapVectorToRotation();

        //check output
        //Debug.Log($"Move Input: {move}");
    }

    private void SetToLimit()
    {
        if (currentRotation.x > maxXRot)
        {
            currentRotation.x = maxXRot;
        }
        else if (currentRotation.x < minXRot)
        {
            currentRotation.x = minXRot;
        }
        else
        {
            return;
        }
    }

    private void MapVectorToRotation()
    {
        rotation = new Vector3(-rot.y * moveSpeed, Mathf.Clamp(rot.x * moveSpeed, minXRot, maxXRot), 0.0f);

        //add rotation value for every frame
        currentRotation += rotation;

        //create auatrnion for new rotation
        Quaternion newRotation = Quaternion.Euler(Mathf.Clamp(currentRotation.x, minXRot, maxXRot), currentRotation.y, currentRotation.z);

        //smotth rotation using slerp
        transform.localRotation = Quaternion.Slerp(transform.rotation, newRotation, smoothSpeed * Time.deltaTime);
    }

    public void ResetRotation() //TODO update seems to intefere with this one
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, defaultRotation, smoothSpeed);
    }

    private void OnEnable()
    {
        controls.CameraController.Enable();
    }

    private void OnDisable()
    {
        controls.CameraController.Disable();
    }
}
