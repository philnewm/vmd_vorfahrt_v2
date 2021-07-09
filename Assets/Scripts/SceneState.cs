using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneState : MonoBehaviour
{
    //member variables
    [SerializeField] string curLang;
    [SerializeField] int curScene;
    [SerializeField] int selectedVehicle;
    [SerializeField] string selectedSide;

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
}
