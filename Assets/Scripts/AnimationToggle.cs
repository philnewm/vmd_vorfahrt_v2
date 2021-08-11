using UnityEngine;

public class AnimationToggle : MonoBehaviour
{
    [SerializeField] VehicleScene vehicleScene;

    public void ControlSwitcher()
    {
        GetComponent<Clicker>().enabled = vehicleScene.GetShow3D();
    }
}
