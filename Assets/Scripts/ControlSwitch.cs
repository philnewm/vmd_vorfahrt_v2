using UnityEngine;

public class ControlSwitch : MonoBehaviour
{
    [SerializeField] VehicleScene vehicleScene;

    public void ControlSwitcher()
    {
        Debug.Log("Hello");
        GetComponent<SimpleRotation>().enabled = !vehicleScene.GetShow3D();
        GetComponent<AdvancedRotation>().enabled = vehicleScene.GetShow3D();
        GetComponent<ZoomControl>().enabled = vehicleScene.GetShow3D();
    }
}
