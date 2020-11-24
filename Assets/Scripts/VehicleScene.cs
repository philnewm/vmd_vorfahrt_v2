using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class VehicleScene : MonoBehaviour
{
    //params
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI year;
    [SerializeField] TextMeshProUGUI descr;
    [SerializeField] TextMeshProUGUI menuYear;
    [SerializeField] SceneState state;
    [SerializeField] DataLoader dataloader;

    [SerializeField] public GameObject basePlate;

    //member variables
    private string jsonString;
    private string path;
    private Vehicle[] vehicle;

    private void Awake()
    {
        InserText();
    }

    private void InserText()
    {
        title.text = dataloader.vehicles[state.GetSelectedVehicle()].GetTitle();
        year.text = dataloader.vehicles[state.GetSelectedVehicle()].GetYear();
        descr.text = dataloader.vehicles[state.GetSelectedVehicle()].Getdescr();
        menuYear.text = dataloader.vehicles[state.GetSelectedVehicle()].GetYear();
    }

    public void SetLanguageEng()
    {
        state.SetLanguage("eng");
        dataloader.vehicles[state.GetSelectedVehicle()].ChangeLanguage(state.GetLanguage());
        InserText();
    }

    public void SetLanguageGer()
    {
        state.SetLanguage("ger");
        dataloader.vehicles[state.GetSelectedVehicle()].ChangeLanguage(state.GetLanguage());
        InserText();
    }
}
