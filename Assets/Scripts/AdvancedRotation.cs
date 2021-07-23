using UnityEngine;

public class AdvancedRotation : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationMinAngle;
    [SerializeField]
    private float rotationMaxAngle;
    private float extractedXRotation;
    private float extractedYRotation;
    private Controls controls;

    private void Awake()
    {
        controls = new Controls();
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
        extractedXRotation += inputVector.y;
        extractedYRotation += inputVector.x;
        extractedXRotation = Mathf.Clamp(extractedXRotation, rotationMinAngle, rotationMaxAngle);
        transform.rotation = Quaternion.Euler(extractedXRotation, extractedYRotation, 0);
    }

    public void disableInput()
    {
        controls.Disable();
    }

    public void enableInput()
    {
        controls.Enable();
    }

    public void ResetXRotation()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
    }
}