using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuScene : MonoBehaviour
{
    //params
    [SerializeField] SceneState state;
    [SerializeField] DataLoader dataloader;
    [SerializeField] Button button4RL;
    [SerializeField] Button buttonRT;
    [SerializeField] TextMeshProUGUI text4RL;
    [SerializeField] TextMeshProUGUI textRT;

    private void Start()
    {
        InsertTitlePic();
        InsertTitle();
    }

    private void InsertTitlePic()
    {
        button4RL.image.sprite = dataloader.vehicles[0].GetTitlePic();
        buttonRT.image.sprite = dataloader.vehicles[1].GetTitlePic();
    }

    private void InsertTitle()
    {
        text4RL.text = dataloader.vehicles[0].GetTitle();
        textRT.text = dataloader.vehicles[1].GetTitle();
    }

    public void SetLanguageEng()
    {
        state.SetLanguage("eng");
        dataloader.vehicles[state.GetSelectedVehicle()].ChangeLanguage(state.GetLanguage());
    }

    public void SetLanguageGer()
    {
        state.SetLanguage("ger");
        dataloader.vehicles[state.GetSelectedVehicle()].ChangeLanguage(state.GetLanguage());
    }
}
