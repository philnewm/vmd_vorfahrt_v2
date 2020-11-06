using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectController : MonoBehaviour
{
    //member variables
    Controls controls;
    Vector2 move;
    Vector3 rotation;
    Vector3 currentRotation;

    //params
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] float minXRot = -35f;
    [SerializeField] float maxXRot = 50f;
    [SerializeField] float smoothSpeed = 7.0f;

    private void Awake()
    {
        controls = new Controls();

        controls.ObjectController.RotationControl.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        controls.ObjectController.RotationControl.canceled += cntxt => move = Vector2.zero;
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
        rotation = new Vector3(move.y * moveSpeed, Mathf.Clamp(-move.x * moveSpeed, minXRot, maxXRot), 0.0f);

        //add rotation value for every frame
        currentRotation += rotation;

        //create auatrnion for new rotation
        Quaternion newRotation = Quaternion.Euler(Mathf.Clamp(currentRotation.x, minXRot, maxXRot), currentRotation.y, currentRotation.z);

        //smotth rotation using slerp
        transform.localRotation = Quaternion.Slerp(transform.rotation, newRotation, smoothSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        controls.ObjectController.Enable();
    }

    private void OnDisable()
    {
        controls.ObjectController.Disable();
    }
}
