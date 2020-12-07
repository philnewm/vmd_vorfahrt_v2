using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneControlText : MonoBehaviour
{
    private SceneState state;
    private DataLoader loader;
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] TextMeshProUGUI descr;
    [SerializeField] Button gerButton;
    [SerializeField] Button engButton;
    [SerializeField] GameObject descrPanel;

    Color greyedColor;  //for chaning language button color to inaktive
    Color defaultColor; // for chaning language button color to aktive

    private void Awake()
    {
        sceneLoader.CheckPreloadScene();
        state = FindObjectOfType<SceneState>(); //find state and loader cause they are using DontDestroyOnLoad
        loader = FindObjectOfType<DataLoader>();

        greyedColor = new Color(100, 100, 100, 100);
        defaultColor = new Color(255, 255, 255, 255);
    }

    private void Start()
    {
        state.SetCurScene();
        descrPanel.GetComponent<Animator>().SetBool("show", true);
        InserText();
    }

    public void SetLanguageEng()
    {
        state.SetLanguage("eng");
        InserText();
        ChangeFLag();
    }
    public void SetLanguageGer()
    {
        state.SetLanguage("ger");
        InserText();
        ChangeFLag();
    }

    public void InserText()
    { 
        if (state.curLang == "ger")
        {
            descr.text = loader.vehicles[state.GetSelectedVehicle()].GetGerPreDescr() + "\n\n"
           + loader.vehicles[state.GetSelectedVehicle()].GetGerDescr();
        }
        else
        {
            descr.text = loader.vehicles[state.GetSelectedVehicle()].GetEngPreDescr() + "\n\n"
            + loader.vehicles[state.GetSelectedVehicle()].GetEngDescr();
        }
    }

    private void ChangeFLag() // still broken
    {
        if (state.curLang == "eng")
        {
            gerButton.image.color = greyedColor;
            engButton.image.color = defaultColor;

            //Debug.Log("Eng Button: " + engButton.image.color);
            //Debug.Log("Ger Button: " + gerButton.image.color);
        }
        else if (state.curLang == "ger")
        {
            engButton.image.color = greyedColor;
            engButton.image.color = defaultColor;

            //Debug.Log("Eng Button: " + engButton.image.color);
            //Debug.Log("Ger Button: " + gerButton.image.color);
        }
    }

    public void ClosingDelay()
    {
        descrPanel.GetComponent<Animator>().SetBool("show", false);
        Invoke ("BackToVehicle", 2);
    }

    private void BackToVehicle()
    {
        sceneLoader.LoadVehicleScene();
    }
}
