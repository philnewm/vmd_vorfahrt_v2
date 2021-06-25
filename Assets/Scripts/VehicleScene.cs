using TMPro;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable CS0649, CS0414 //suppress non relevant warnings

public class VehicleScene : MonoBehaviour
{
    //accessable members
    [SerializeField] SceneLoader sceneLoader;

    [Header("Button")]
    [SerializeField] TextMeshProUGUI threedFullBtn;
    [SerializeField] TextMeshProUGUI textFullBtn;
    [SerializeField] GameObject pageNum;
    [SerializeField] GameObject pagePanel;

    [Header("VehicleData")]
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI year;
    [SerializeField] TextMeshProUGUI descr;
    [SerializeField] TextMeshProUGUI menuYear;
    [SerializeField] GameObject magImg;
    [SerializeField] GameObject rt, rl;
    [SerializeField] GameObject magazinePanel;
    [SerializeField] GameObject descrPanel;
    [SerializeField] GameObject blueBG;
    [SerializeField] GameObject pageSlides;
    [SerializeField] GameObject nextSlideBtn;
    [SerializeField] GameObject prevSlideBtn;
    [SerializeField] GameObject ExitBtn;

    //member variables
    private int slideNum;       //switch gallery slides

    //non-accessable members
    private SceneState state;
    private DataLoader loader;
    private int galSlides;      //loading gallery slides
    private bool showGal, showDescr, showBlueBG = false;  //indicator if gallery images are in use or not
    private int displaySlideNum;
    private int displaySlides;

    private void Awake()
    {
        //all operations in here depent on DontDestroyOnLoad-Feature ()SceneState.cs --> Awake-Methode
        sceneLoader.CheckPreloadScene();
        state = FindObjectOfType<SceneState>(); //find state-script
        loader = FindObjectOfType<DataLoader>(); //find loader-script
    }

    private void Start()
    {
        state.SetCurScene();
        SetSlides();
        PrepopSlideNum();
        CheckVehicleID();
        InserText();
        InsertGallery();
        prevSlideBtn.SetActive(showGal);
        nextSlideBtn.SetActive(showGal);
    }

    private void SetSlides()
    {
        galSlides = loader.vehicles[state.GetSelectedVehicle()].gallery.Count - 1;
        slideNum = 0;
    }

    private void PrepopSlideNum()
    {
        displaySlideNum = 1;
        displaySlides = galSlides + 1;
        pageNum.GetComponent<TextMeshProUGUI>().text = displaySlideNum + "/" + displaySlides;
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
        LoadLangIndText();

        if (state.curLang == "ger")
        {
            LoadGerText();
        }
        else
        {
            LoadEngText();
        }
    }

    private void LoadLangIndText()
    {
        title.text = loader.vehicles[state.GetSelectedVehicle()].GetTitle();
        year.text = loader.vehicles[state.GetSelectedVehicle()].GetYear();
        menuYear.text = loader.vehicles[state.GetSelectedVehicle()].GetYear();
    }

    private void LoadGerText()
    {
        threedFullBtn.text = "3D-Vollbild";
        textFullBtn.text = "Text-Vollbild";
        pagePanel.GetComponent<TextMeshProUGUI>().text = "Seite";

        descr.text = loader.vehicles[state.GetSelectedVehicle()].GetGerPreDescr() + "\n\n"
       + loader.vehicles[state.GetSelectedVehicle()].GetGerDescr();
    }
    private void LoadEngText()
    {
        threedFullBtn.text = "3D-Fullscreen";
        textFullBtn.text = "Text-Fullscreen";
        pagePanel.GetComponent<TextMeshProUGUI>().text = "Page";

        descr.text = loader.vehicles[state.GetSelectedVehicle()].GetEngPreDescr() + "\n\n"
        + loader.vehicles[state.GetSelectedVehicle()].GetEngDescr();
    }

    private void InsertGallery()
    {
        magImg.GetComponent<RawImage>().texture = loader.vehicles[state.GetSelectedVehicle()].GetMagazine()[slideNum];
    }

    public void NextSlide(int direction)
    {
        //set slide-numbers
        displaySlideNum = 1;
        displaySlides = galSlides + 1;

        if (slideNum >= galSlides && direction == 1)
        {
            MoveToStart();
            NumDisplayConversion();
        }
        else if (slideNum <= 0 && direction == -1)
        {
            MoveToEnd();
            NumDisplayConversion();
        }
        else
        {
            ChangeSlideNum(direction);
            NumDisplayConversion();
        }
    }

    private void MoveToStart()
    {
        slideNum = 0;
        magImg.GetComponent<RawImage>().texture = loader.vehicles[state.GetSelectedVehicle()].GetMagazine()[slideNum];
    }

    private void MoveToEnd()
    {
        slideNum = galSlides;
        magImg.GetComponent<RawImage>().texture = loader.vehicles[state.GetSelectedVehicle()].GetMagazine()[slideNum];
    }

    private void ChangeSlideNum(int direction)
    {
        slideNum += direction;
        magImg.GetComponent<RawImage>().texture = loader.vehicles[state.GetSelectedVehicle()].GetMagazine()[slideNum];
    }

    private void NumDisplayConversion()
    {
        displaySlideNum += slideNum;
        pageNum.GetComponent<TextMeshProUGUI>().text = displaySlideNum + "/" + displaySlides;
    }

    public void FadeGallery()
    {
        if (showGal) { showGal = false; }
        else { showGal = true; }

        magazinePanel.GetComponent<Animator>().SetBool("show", showGal);
        pageSlides.SetActive(!showGal);
        prevSlideBtn.SetActive(showGal);
        nextSlideBtn.SetActive(showGal);
        ExitBtn.SetActive(showGal);
        pageNum.SetActive(showGal);
        pagePanel.SetActive(showGal);
    }
}