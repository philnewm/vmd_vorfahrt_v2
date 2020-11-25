using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VehicleScene : MonoBehaviour
{
    //params
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI year;
    [SerializeField] TextMeshProUGUI descr;
    [SerializeField] TextMeshProUGUI menuYear;

    [SerializeField] public GameObject basePlate;

    //member variables
    SceneState state;
    DataLoader dataloader;
    private string jsonString;
    private string path;
    private Vehicle[] vehicle;

    private void Awake()
    {
        state = FindObjectOfType<SceneState>();
        dataloader = FindObjectOfType<DataLoader>();
    }

    private void Start()
    {
        InserText();
        //InsertVehicleModell();
        //InsertBase();
        //InsertMagazine();
        //InsertGallery();
    }

    public void InserText()
    {
        title.text = dataloader.vehicles[state.GetSelectedVehicle()].GetTitle();
        year.text = dataloader.vehicles[state.GetSelectedVehicle()].GetYear();
        descr.text = dataloader.vehicles[state.GetSelectedVehicle()].Getdescr();
        menuYear.text = dataloader.vehicles[state.GetSelectedVehicle()].GetYear();
    }
}
