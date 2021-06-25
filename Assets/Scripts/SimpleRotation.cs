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
        angle += controls.SceneController.vertical_rotation.ReadValue<float>() * speed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, angle, 0);
    }
}
