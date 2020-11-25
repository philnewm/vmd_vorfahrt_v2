using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneState : MonoBehaviour
{
    //member variables
    [SerializeField] public string curLang = "ger";
    [SerializeField] public int curScene;
    [SerializeField] public int selectedVehicle;

    private void Awake()
    {
        CheckIfExists();
        SetCurScene();
    }

    private void CheckIfExists()
    {
        int DataLoaderCount = FindObjectsOfType<DataLoader>().Length;
        if (DataLoaderCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
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
