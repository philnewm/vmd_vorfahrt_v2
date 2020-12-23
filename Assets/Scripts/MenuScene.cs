using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable CS0649 //suppress non relevant warnings

public class MenuScene : MonoBehaviour
{
    //params
    SceneState state;
    DataLoader loader;
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] Button button4RL;
    [SerializeField] Button buttonRT;
    [SerializeField] TextMeshProUGUI text4RL;
    [SerializeField] TextMeshProUGUI textRT;
    [SerializeField] TextMeshProUGUI year4RL;
    [SerializeField] TextMeshProUGUI yearRT;
    [SerializeField] Button gerButton;
    [SerializeField] Button engButton;
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
        InsertTitlePic();
        InsertTitle();
        InsertYear();
    }

    private void InsertTitlePic()
    {
        button4RL.GetComponent<RawImage>().texture = loader.vehicles[0].GetTitlePic();
        buttonRT.GetComponent<RawImage>().texture = loader.vehicles[1].GetTitlePic();
    }

    private void InsertTitle()
    {
        text4RL.text = loader.vehicles[0].GetTitle();
        textRT.text = loader.vehicles[1].GetTitle();
    }

    private void InsertYear()
    {
        year4RL.text = loader.vehicles[0].GetYear();
        yearRT.text = loader.vehicles[1].GetYear();
    }

    public void SetLanguageEng()
    {
        state.SetLanguage("eng");
        ChangeFLag();
    }

    public void SetLanguageGer()
    {
        state.SetLanguage("ger");
        ChangeFLag();
    }

    private void ChangeFLag() // still broken
    {
        if (state.curLang == "eng")
        {
            gerButton.image.color = greyedColor;
            engButton.image.color = defaultColor;

            Debug.Log("Eng Button: " + engButton.image.color);
            Debug.Log("Ger Button: " + gerButton.image.color);
        }
        else if (state.curLang == "ger")
        {
            engButton.image.color = greyedColor;
            engButton.image.color = defaultColor;

            Debug.Log("Eng Button: " + engButton.image.color);
            Debug.Log("Ger Button: " + gerButton.image.color);
        }
    }

    public void SwitchVehicle( int num)
    {
        state.SetSelectedVehicle(num);
    }
}
