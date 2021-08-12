using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneState : MonoBehaviour
{
    //member variables
    [SerializeField] string curLang;
    [SerializeField] int curScene;
    [SerializeField] int selectedVehicle;
    [SerializeField] int loadedSide;
    [SerializeField] string selectedSide;
    [SerializeField] int visibleCountdown;
    [SerializeField] int invisibleCountdown;

    private DataLoader loader;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        loader = FindObjectOfType<DataLoader>();
        selectedVehicle = 0;
        curLang = "ger";
        SetCurScene();
    }

    //user defined functions
    public string GetLanguage()
    {
        return curLang;
    }

    public void SetLanguage(string language)
    {
        this.curLang = language;
    }

    public void SetCurScene()
    {
        curScene = SceneManager.GetActiveScene().buildIndex;
    }

    public int GetSelectedVehicle()
    {
        return selectedVehicle;
    }

    public void SetSelectedVehicle(int VehicleNumber)
    {
        this.selectedVehicle = VehicleNumber;
    }

    public void SetSelectedSide(string jsonData)
    {
        JsonUtility.FromJsonOverwrite(jsonData, this);
        if (loadedSide == 1)
        {
            selectedSide = "right";
        }
        else
        {
            selectedSide = "left";
        }
    }

    public int GetLoadedSide()
    {
        return loadedSide;
    }

    public string GetSelectedSide()
    {
        return selectedSide;
    }

    public void SetInvisCountdown(int invisCountdown)
    {
        invisibleCountdown = invisCountdown;
    }

    public void SetVisCountdown(int visCountdown)
    {
        visibleCountdown = visCountdown;
    }

    public int GetVisCountdown()
    {
        return visibleCountdown;
    }

    public int GetInvisCountdown()
    {
        return invisibleCountdown;
    }
}
