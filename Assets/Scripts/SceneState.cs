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

    private DataLoader loader;

    private void Awake()
    {
		DontDestroyOnLoad(gameObject);
        loader = FindObjectOfType<DataLoader>();
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
        Debug.Log(curScene);
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
