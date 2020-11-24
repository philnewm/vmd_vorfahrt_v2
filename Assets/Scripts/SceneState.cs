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
    [SerializeField] public int selectedVehicle = 1;

    [SerializeField] Button gerButton;
    [SerializeField] Button engButton;

    Color greyedColor;
    Color defaultColor;


    private void Awake()
    {
        SetCurScene();
        greyedColor = new Color(100, 100, 100, 100);
        defaultColor = new Color(255, 255, 255, 255);
    }


    //user defined functions
    public string GetLanguage()
    {
        return curLang;
    }

    public void SetLanguage(string language)
    {
        this.curLang = language;

        ChangFLag(language);
    }

    private void ChangFLag(string language)
    {
        if (language == "eng")
        {
            gerButton.image.color = greyedColor;
            engButton.image.color = defaultColor;

            Debug.Log("Eng Button: " + engButton.image.color);
            Debug.Log("Ger Button: " + gerButton.image.color);
        }
        else if (language == "ger")
        {
            engButton.image.color = greyedColor;
            gerButton.image.color = defaultColor;

            Debug.Log("Eng Button: " + engButton.image.color);
            Debug.Log("Ger Button: " + gerButton.image.color);
        }
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
