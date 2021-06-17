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

    [Header("External Scripts")]
    [SerializeField] SceneLoader sceneLoader;

    [Header("Button")]
    [SerializeField] Button button4RL;
    [SerializeField] Button buttonRT;

    [Header("Text Panel")]
    [SerializeField] TextMeshProUGUI text4RL;
    [SerializeField] TextMeshProUGUI textRT;
    [SerializeField] TextMeshProUGUI year4RL;
    [SerializeField] TextMeshProUGUI yearRT;

    private void Awake()
    {
        sceneLoader.CheckPreloadScene();
        state = FindObjectOfType<SceneState>(); //find state and loader cause they are using DontDestroyOnLoad
        loader = FindObjectOfType<DataLoader>();
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

    public void SwitchVehicle( int num)
    {
        state.SetSelectedVehicle(num);
    }
}
