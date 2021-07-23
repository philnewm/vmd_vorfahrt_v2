using UnityEngine;

public class ControlSwitch : MonoBehaviour
{
    [SerializeField] VehicleScene vehicleScene;

    public void ControlSwitcher()
    {
        GetComponent<SimpleRotation>().enabled = !vehicleScene.GetShow3D();
        GetComponent<AdvancedRotation>().enabled = vehicleScene.GetShow3D();
        GetComponent<ZoomControl>().enabled = vehicleScene.GetShow3D();
    }
}
