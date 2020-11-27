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
    [SerializeField] Image magImg;
    [SerializeField] GameObject rt, rl;
    [SerializeField] GameObject magazinePanel;
    [SerializeField] GameObject pageSlides;
    [SerializeField] GameObject nextSlideBtn;
    [SerializeField] GameObject prevSlideBtn;

    [SerializeField] public GameObject basePlate;

    //member variables
    SceneState state;
    DataLoader dataloader;
    private string jsonString;
    private string path;
    private Vehicle[] vehicle;
    public int slideNum;
    private int magSlides;
    private bool show = false;

    private void Awake()
    {
        state = FindObjectOfType<SceneState>();
        dataloader = FindObjectOfType<DataLoader>();

        if (state.GetSelectedVehicle() == 0)
        {
            rt.SetActive(false);
            rl.SetActive(true);
        }
        else
        {
            rt.SetActive(true);
            rl.SetActive(false);
        }
        magSlides = dataloader.vehicles[state.GetSelectedVehicle()].GetMagazine().Length-1;
        slideNum = 0;
    }

    private void Start()
    {
        InserText();
        //InsertVehicleModell();
        //InsertBase();
        InsertMagazine();
        //InsertGallery();
        prevSlideBtn.SetActive(show);
        nextSlideBtn.SetActive(show);
    }

    public void InserText()
    {
        title.text = dataloader.vehicles[state.GetSelectedVehicle()].GetTitle();
        year.text = dataloader.vehicles[state.GetSelectedVehicle()].GetYear();
        descr.text = dataloader.vehicles[state.GetSelectedVehicle()].GetPreDescr() + "\n\n"
                   + dataloader.vehicles[state.GetSelectedVehicle()].Getdescr();
        menuYear.text = dataloader.vehicles[state.GetSelectedVehicle()].GetYear();
    }
    private void InsertMagazine()
    {
        magImg.sprite = dataloader.vehicles[state.GetSelectedVehicle()].GetMagazine()[slideNum];
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
            magImg.sprite = dataloader.vehicles[state.GetSelectedVehicle()].GetMagazine()[slideNum];
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
            magImg.sprite = dataloader.vehicles[state.GetSelectedVehicle()].GetMagazine()[slideNum];
        }
    }
    public void FadeIt()
    {
        if (show) show = false;
        else show = true;
        magazinePanel.GetComponent<Animator>().SetBool("Show", show);
        pageSlides.SetActive(!show);
        prevSlideBtn.SetActive(show);
        nextSlideBtn.SetActive(show);
    }
}
