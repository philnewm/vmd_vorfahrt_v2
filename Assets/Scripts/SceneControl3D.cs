using UnityEngine;
#pragma warning disable CS0649 //suppress non-relevant warnings

public class SceneControl3D : MonoBehaviour
{
    //accessable members
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] GameObject modellAsTexture;
    [SerializeField] GameObject driverDoorBtn, coDriverDoorBtn, engineCoverBtn;

    [Header("3D Objects")]
    [SerializeField] GameObject modelCtl;
    [SerializeField] Vector3 modelDefaultPosition;
    [SerializeField] Quaternion modelDefaultRotation;

    //non-accessable members
    private SceneState state;
    private DataLoader loader;
    private void Awake()
    {
        //all operations in here depent on DontDestroyOnLoad-Feature ()SceneState.cs --> Awake-Methode
        sceneLoader.CheckPreloadScene();
        state = FindObjectOfType<SceneState>(); //find state-script
        loader = FindObjectOfType<DataLoader>(); //find dataloader-script
        Insert3DModel();
    }

    private void Start()
    {
        state.SetCurScene();    //update scene index
        CheckVehicleID();
        modellAsTexture.GetComponent<Animator>().SetBool("upscaled", true);
    }

    private void CheckVehicleID()
    {
        if (state.GetSelectedVehicle() == 3 && state.GetLoadedSide() == 0) //check which vehicle to display, value found in state-class
        {
            Display4rl();
        }
        else
        {
            Displayrt();
        }
    }

    private void Display4rl()
    {
        driverDoorBtn.SetActive(true);
        coDriverDoorBtn.SetActive(true);
        engineCoverBtn.SetActive(true);
    }

    private void Displayrt()
    {
        driverDoorBtn.SetActive(false);
        coDriverDoorBtn.SetActive(false);
        engineCoverBtn.SetActive(false);
    }

    private void Insert3DModel()
    {
        GameObject vehicleModel = Instantiate(loader.vehicles[state.GetSelectedVehicle()].Get3DModel(), modelDefaultPosition, modelDefaultRotation, modelCtl.transform);
    }
}