using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] ObjectRotation objectRotation;
    private Controls controls;

    private void Awake()
    {
        controls = new Controls();
    }

    private void Start()
    {
        controls.SceneController.Click.performed += _ => StartedClick();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void StartedClick()
    {
        DetectObject();
    }

    private void DetectObject()
    {
        Ray ray = camera.ScreenPointToRay(controls.SceneController.Position.ReadValue<Vector2>());

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.collider.tag == "Cover")
            {
                objectRotation.ToggleCover();
            }
            else if (hit.collider != null && hit.collider.tag == "DriverDoor")
            {
                objectRotation.ToggleDriverDoor();
            }
            else if (hit.collider != null && hit.collider.tag == "CoDriverDoor")
            {
                objectRotation.ToggleCoDoor();
            }
        }
        else
        {
            Debug.Log("Missed");
        }
    }
}
