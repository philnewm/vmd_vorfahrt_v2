using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    //accessible members
    [SerializeField] float autoSpeed;
    [SerializeField] float manSpeed;
    [SerializeField] Timer timer;
    [SerializeField] VehicleScene vehicleScene;
    [SerializeField] float timeLimit;
    //non-accessible members
    private Controls controls;
    private float angle;

    float elapsedTime;

    private void Awake()
    {
        controls = new Controls();
        elapsedTime = 0;
    }

    private void OnEnable()
    {
        angle = vehicleScene.GetCurRotValue();
        controls.Enable();
    }

    private void OnDisable()
    {
        vehicleScene.SetCurrentRotationAngle(angle);
        controls.Disable();
    }

    void Update()
    {
        if (controls.SceneController.RotationControl.ReadValue<Vector2>() != new Vector2(0, 0))
        {
            CameraYRotation();
        }
        else if (elapsedTime >= timeLimit)
        {
            autoRotate();
        }

        elapsedTime += Time.deltaTime;

    }

    private void CameraYRotation()
    {
        Vector2 inputVector = controls.SceneController.RotationControl.ReadValue<Vector2>() * autoSpeed * Time.deltaTime;
        angle += inputVector.x * manSpeed;
        //TODO add boundaries
        transform.rotation = Quaternion.Euler(0, angle, 0);
        timer.ResetTimer();
        elapsedTime = 0;
    }

    private void autoRotate()
    {
        angle -= autoSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, angle, 0);
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
