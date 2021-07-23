using UnityEngine;
using UnityEngine.EventSystems;
#pragma warning disable CS0108, CS0649 //suppress non relevant warnings

public class ZoomControl : MonoBehaviour
{
    //accessible members
    [SerializeField] AdvancedRotation advancedRotation;

    [Header("Slider Zoom")]
    [SerializeField] float maxZoomLvl;
    [SerializeField] float minZoomLvl;
    [Tooltip("Change minimum FOV by chaning FOV in camera object itself.")]
    [SerializeField] float maxFOV;

    [Header("Camera Reference")]
    [SerializeField] Camera camera;
    private Vector3 startCameraPosition;
    private Vector3 defaultCameraPosition;
    private float minFOV;
    private float defaultFOV;

    private void Start()
    {
        startCameraPosition = camera.transform.localPosition;
        defaultCameraPosition = camera.transform.localPosition;
        minFOV = camera.fieldOfView;
        defaultFOV = 30;
    }

    public void SliderZoom(float zoomValue)
    {
        advancedRotation.disableInput();

        float newzoom = minZoomLvl + zoomValue * (maxZoomLvl - minZoomLvl);

        camera.transform.localPosition = startCameraPosition + new Vector3(0, 0, newzoom);

        camera.fieldOfView = minFOV + zoomValue * (maxFOV - minFOV);

        advancedRotation.enableInput();
    }

    public void ResetCam()
    {
        camera.fieldOfView = defaultFOV;
        camera.transform.localPosition = defaultCameraPosition;
    }
}
