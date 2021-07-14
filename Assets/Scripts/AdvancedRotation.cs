using UnityEngine;

public class AdvancedRotation : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationMinAngle;
    [SerializeField]
    private float rotationMaxAngle;
    private float exctractedXRotation;
    private float exctractedYRotation;


    private Controls controls;

    private void Awake()
    {
        controls = new Controls();
        exctractedXRotation = transform.rotation.x;
        exctractedYRotation = transform.rotation.y;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        UpdateXYRotation();
    }

    public void UpdateXYRotation()
    {
        Vector2 inputVector = controls.SceneController.RotationControl.ReadValue<Vector2>() * speed * Time.deltaTime;
        exctractedXRotation += inputVector.y;
        exctractedYRotation += inputVector.x;
        exctractedXRotation = Mathf.Clamp(exctractedXRotation, rotationMinAngle, rotationMaxAngle);
        transform.eulerAngles = new Vector3(exctractedXRotation, exctractedYRotation, 0);
    }

    public void disableInput()
    {
        controls.Disable();
    }

    public void enableInput()
    {
        controls.Enable();
    }
}