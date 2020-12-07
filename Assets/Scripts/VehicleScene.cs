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
    [SerializeField] SceneLoader sceneLoader;

    [Header("VehicleData")]
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI year;
    [SerializeField] TextMeshProUGUI descr;
    [SerializeField] TextMeshProUGUI menuYear;
    [SerializeField] Image magImg;
    [SerializeField] GameObject rt, rl;
    [SerializeField] GameObject magazinePanel;
    [SerializeField] GameObject descrPanel;
    [SerializeField] GameObject blueBG;
    [SerializeField] GameObject pageSlides;
    [SerializeField] GameObject nextSlideBtn;
    [SerializeField] GameObject prevSlideBtn;
    [SerializeField] Button gerButton;
    [SerializeField] Button engButton;
    [SerializeField] GameObject ExitBtn;

    //member variables
    SceneState state;
    DataLoader loader;
    public int slideNum;        //switch gallery slides
    private int magSlides;      //loading gallery slides
    private bool showMag, showDescr, showBlueBG = false;  //indicator if gallery images are in use or not
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

    private void SetSlides()
    {
        magSlides = loader.vehicles[state.GetSelectedVehicle()].GetMagazine().Length - 1;
        slideNum = 0;
    }

    private void Start()
    {
        state.SetCurScene();
        SetSlides();
        CheckVehicleID();
        InserText();
        //InsertVehicleModell();
        //InsertBase();
        InsertMagazine();
        //InsertGallery();
        prevSlideBtn.SetActive(showMag);
        nextSlideBtn.SetActive(showMag);
    }

    private void CheckVehicleID()
    {
        if (state.GetSelectedVehicle() == 0) //check wich vehicle to display, value found in state-class
        {
            rt.SetActive(false);
            rl.SetActive(true);
        }
        else
        {
            rt.SetActive(true);
            rl.SetActive(false);
        }
    }

    public void InserText()
    {
        title.text = loader.vehicles[state.GetSelectedVehicle()].GetTitle();
        year.text = loader.vehicles[state.GetSelectedVehicle()].GetYear();
        menuYear.text = loader.vehicles[state.GetSelectedVehicle()].GetYear();

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
    private void InsertMagazine()
    {
        magImg.sprite = loader.vehicles[state.GetSelectedVehicle()].GetMagazine()[slideNum];
    }

    public void NextSlide()
    {
        if (slideNum >= magSlides)
        {
            return;
        }
        else
        {
            slideNum++;
            magImg.sprite = loader.vehicles[state.GetSelectedVehicle()].GetMagazine()[slideNum];
        }
    }

    public void PrevSlide()
    {
        if (slideNum <= 0)
        {
            return;
        }
        else
        {
            slideNum--;
            magImg.sprite = loader.vehicles[state.GetSelectedVehicle()].GetMagazine()[slideNum];
        }
    }
    public void FadeMagazine()
    {
        if (showMag) showMag = false;
        else showMag = true;
        magazinePanel.GetComponent<Animator>().SetBool("show", showMag);
        pageSlides.SetActive(!showMag);
        prevSlideBtn.SetActive(showMag);
        nextSlideBtn.SetActive(showMag);
        ExitBtn.SetActive(showMag);
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
}