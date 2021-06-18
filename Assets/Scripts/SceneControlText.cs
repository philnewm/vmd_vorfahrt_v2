using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable CS0649 //suppress non relevant warnings

public class SceneControlText : MonoBehaviour
{
    private SceneState state;
    private DataLoader loader;
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] TextMeshProUGUI descr;
    [SerializeField] GameObject descrPanel;

    Color greyedColor;  //for chaning language button color to inaktive
    Color defaultColor; // for chaning language button color to aktive

    private void Awake()
    {
        sceneLoader.CheckPreloadScene();
        state = FindObjectOfType<SceneState>(); //find state and loader cause they are using DontDestroyOnLoad
        loader = FindObjectOfType<DataLoader>();
    }

    private void Start()
    {
        state.SetCurScene();
        descrPanel.GetComponent<Animator>().SetBool("show", true);
        InserText();
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
