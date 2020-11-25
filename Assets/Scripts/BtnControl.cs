using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnControl : MonoBehaviour
{
    [SerializeField] Button gerButton;
    [SerializeField] Button engButton;

    SceneState state;
    DataLoader loader;

    Color greyedColor;
    Color defaultColor;
    private void Awake()
    {
        state = FindObjectOfType<SceneState>();
        loader = FindObjectOfType<DataLoader>();
        greyedColor = new Color(100, 100, 100, 100);
        defaultColor = new Color(255, 255, 255, 255);
    }

    public void SetLanguageEng()
    {
        state.SetLanguage("eng");
        loader.vehicles[state.GetSelectedVehicle()].ChangeLanguage(state.GetLanguage());
    }

    public void SetLanguageGer()
    {
        state.SetLanguage("ger");
        loader.vehicles[state.GetSelectedVehicle()].ChangeLanguage(state.GetLanguage());
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
            engButton.image.color = defaultColor;

            Debug.Log("Eng Button: " + engButton.image.color);
            Debug.Log("Ger Button: " + gerButton.image.color);
        }
    }

    public void SetVehicleFix(int curVehicle)
    {
        state.SetSelectedVehicle(curVehicle);
    }
}
