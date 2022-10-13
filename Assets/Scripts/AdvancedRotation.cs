using UnityEngine;

public class AdvancedRotation : MonoBehaviour
{

    [SerializeField] Timer timer;
    [SerializeField] private float rotationMinAngle;
    [SerializeField] private float rotationMaxAngle;

    [SerializeField] float autoSpeed;
    [SerializeField] float manSpeed;
    [SerializeField] private VehicleScene vehicleScene;
    [SerializeField] float timeLimit;
    private float curRotY;
    float elapsedTime;
    private float extractedXRotation;
    private float extractedYRotation;
    private Controls controls;

    private float curYValue;

    private void Awake()
    {
        controls = new Controls();
        elapsedTime = 0;
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
        if (controls.SceneController.RotationControl.ReadValue<Vector2>() != new Vector2(0, 0))
        {
            UpdateXYRotation();
        }
        else if (elapsedTime >= timeLimit)
        {
            autoRotate();
        }

        elapsedTime += Time.deltaTime;
        // UpdateXYRotation();
    }

    public void UpdateXYRotation()
    {
        Vector2 inputVector = controls.SceneController.RotationControl.ReadValue<Vector2>() * manSpeed * Time.deltaTime;

        if (inputVector != new Vector2(0, 0))
        {
            extractedXRotation += inputVector.y;
            extractedYRotation += inputVector.x;
            extractedXRotation = Mathf.Clamp(extractedXRotation, rotationMinAngle, rotationMaxAngle);
            transform.rotation = Quaternion.Euler(extractedXRotation, extractedYRotation, 0);

            timer.ResetTimer();
            elapsedTime = 0;
        }
    }

    public void ResetXRotation()
    {
        extractedXRotation = 0;
        transform.rotation = Quaternion.Euler(extractedXRotation, extractedYRotation, 0);
    }

    private void autoRotate()
    {
        extractedYRotation -= autoSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, extractedYRotation, 0);
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