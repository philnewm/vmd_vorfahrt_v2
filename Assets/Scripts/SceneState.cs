using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneState : MonoBehaviour
{
    //member variables
    [SerializeField] string curLang = "ger";
    [SerializeField] string curVehicle;
    [SerializeField] int curScene;

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

    public string GetCurVehicle()
    {
        return curVehicle;
    }

    public void SetCurVehicle(string curVehicle)
    {
        this.curVehicle = curVehicle;
    }

    public void SetCurScene()
    {
        curScene = SceneManager.GetActiveScene().buildIndex;
    }
}
