using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    //accessible members
    [SerializeField] float speed;
    [SerializeField] Timer timer;
    [SerializeField]
    VehicleScene vehicleScene;

    //non-accessible members
    private Controls controls;
    private float angle;

    private void Awake()
    {
        controls = new Controls();
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
        CameraYRotation();
    }

    private void CameraYRotation()
    {
        Vector2 inputVector = controls.SceneController.RotationControl.ReadValue<Vector2>() * speed * Time.deltaTime;
        if (inputVector != new Vector2(0, 0))
        {
            angle += inputVector.x;
            //TODO add boundaries
            transform.rotation = Quaternion.Euler(0, angle, 0);
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
