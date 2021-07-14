using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    //accessible members
    [SerializeField] float speed;

    //non-accessible members
    private Controls controls;
    private float angle;

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

    private void Start()
    {
        angle = transform.rotation.y;
    }

    void Update()
    {
        CameraYRotation();
    }

    private void CameraYRotation()
    {
        Vector2 inputVector = controls.SceneController.RotationControl.ReadValue<Vector2>() * speed * Time.deltaTime;
        angle += inputVector.x;
        transform.eulerAngles = new Vector3(0, angle, 0);
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
