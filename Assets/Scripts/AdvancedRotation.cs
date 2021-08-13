using UnityEngine;

public class AdvancedRotation : MonoBehaviour
{

    [SerializeField] Timer timer;
    [SerializeField] private float speed;
    [SerializeField] private float rotationMinAngle;
    [SerializeField] private float rotationMaxAngle;
    [SerializeField] private VehicleScene vehicleScene;
    private float curRotY;

    private float extractedXRotation;
    private float extractedYRotation;
    private Controls controls;

    private float curYValue;

    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        extractedYRotation = vehicleScene.GetCurRotValue();
        controls.Enable();
    }

    private void OnDisable()
    {
        vehicleScene.SetCurrentRotationAngle(extractedYRotation);
        controls.Disable();
    }

    void Update()
    {
        UpdateXYRotation();
    }

    public void UpdateXYRotation()
    {
        Vector2 inputVector = controls.SceneController.RotationControl.ReadValue<Vector2>() * speed * Time.deltaTime;

        if (inputVector != new Vector2(0, 0))
        {
            extractedXRotation += inputVector.y;
            extractedYRotation += inputVector.x;
            extractedXRotation = Mathf.Clamp(extractedXRotation, rotationMinAngle, rotationMaxAngle);
            transform.rotation = Quaternion.Euler(extractedXRotation, extractedYRotation, 0);

            timer.ResetTimer();
        }
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