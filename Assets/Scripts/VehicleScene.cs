using TMPro;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable CS0649, CS0414 //suppress non relevant warnings

public class VehicleScene : MonoBehaviour
{
    //accessable members
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] GameObject camCtl;
    [Header("Button")]
    [SerializeField] GameObject pagePanel;
    [SerializeField] GameObject langPanel;

    [Header("VehicleData")]
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI year;
    [SerializeField] TextMeshProUGUI menuYear;


    [Header("TextData")]
    [SerializeField] TextMeshProUGUI textFullBtn;
    [SerializeField] TextMeshProUGUI descr;
    [SerializeField] GameObject descrPanel;
    [SerializeField] GameObject blueBG;
    [SerializeField] GameObject exitBtnText;

    [Header("Gallery Data")]
    [SerializeField] GameObject pageSlides;
    [SerializeField] GameObject pageNum;
    [SerializeField] GameObject galImg;
    [SerializeField] GameObject galPanel;
    [SerializeField] GameObject nextSlideBtn;
    [SerializeField] GameObject prevSlideBtn;
    [SerializeField] GameObject exitBtnGal;

    [Header("3D Objects")]
    [SerializeField] TextMeshProUGUI threedFullBtn;
    [SerializeField] GameObject modelTexture;
    [SerializeField] GameObject whiteBG;
    [SerializeField] GameObject modelCtl;
    [SerializeField] GameObject zoomSlider;
    [SerializeField] Vector3 modelDefaultPosition;
    [SerializeField] Quaternion modelDefaultRotation;
    [SerializeField] GameObject exitBtn3D;
    [SerializeField] AdvancedRotation advancedRotation;
    [SerializeField] private Quaternion curRot;
    [SerializeField] int animModelArrayPos;

    //member variables
    private int slideNum;       //switch gallery slides

    //non-accessable members
    private SceneState state;
    private DataLoader loader;
    private int galSlides;      //loading gallery slides
    private bool showGal, show3D, showText;
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
        show3D = false;
        showGal = false;
        showText = false;
        SetSlides();
        PrepopSlideNum();
        //CheckVehicleID();
        InserText();
        InsertGallery();
        Insert3DModel();
        prevSlideBtn.SetActive(showGal);
        nextSlideBtn.SetActive(showGal);
        curRot = modelCtl.transform.rotation;
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

    public void InserText()
    {
        LoadLangAndText();

        if (state.GetLanguage() == "ger")
        {
            LoadGerText();
        }
        else
        {
            LoadEngText();
        }
    }

    private void LoadLangAndText()
    {
        if (state.GetLanguage() == "ger")
        {
            title.text = loader.vehicles[state.GetSelectedVehicle()].GetGerTitle();
        }
        else
        {
            title.text = loader.vehicles[state.GetSelectedVehicle()].GetEngTitle();
        }

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
        galImg.GetComponent<RawImage>().texture = loader.vehicles[state.GetSelectedVehicle()].GetGallery()[slideNum];
    }

    private void Insert3DModel()
    {
        GameObject vehicleModel = Instantiate(loader.vehicles[state.GetSelectedVehicle()].Get3DModel(), modelDefaultPosition, modelDefaultRotation, modelCtl.transform);
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
        galImg.GetComponent<RawImage>().texture = loader.vehicles[state.GetSelectedVehicle()].GetGallery()[slideNum];
    }

    private void MoveToEnd()
    {
        slideNum = galSlides;
        galImg.GetComponent<RawImage>().texture = loader.vehicles[state.GetSelectedVehicle()].GetGallery()[slideNum];
    }

    private void ChangeSlideNum(int direction)
    {
        slideNum += direction;
        galImg.GetComponent<RawImage>().texture = loader.vehicles[state.GetSelectedVehicle()].GetGallery()[slideNum];
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

        galPanel.transform.SetAsLastSibling();

        galPanel.GetComponent<Animator>().SetBool("show", showGal);
        pageSlides.SetActive(!showGal);
        prevSlideBtn.SetActive(showGal);
        nextSlideBtn.SetActive(showGal);
        exitBtnGal.SetActive(showGal);
        pageNum.SetActive(showGal);
        pagePanel.SetActive(showGal);
    }

    public bool GetShowText()
    {
        return showText;
    }

    public void FadeText()
    {
        if (showText)
        {
            showText = false;
        }
        else
        {
            showText = true;
            blueBG.SetActive(showText);
            exitBtnText.SetActive(showText);
        }

        ReArrangeHirarchyText();
        StartTextAnimations();
    }

    private void ReArrangeHirarchyText()
    {
        blueBG.transform.SetAsLastSibling();
        exitBtnText.transform.SetAsLastSibling();
        descrPanel.transform.SetAsLastSibling();
        langPanel.transform.SetAsLastSibling();
    }

    private void StartTextAnimations()
    {
        descrPanel.GetComponent<Animator>().SetBool("show", showText);
        blueBG.GetComponent<Animator>().SetBool("show", showText);
        exitBtnText.GetComponent<Animator>().SetBool("show", showText);
    }

    public bool GetShow3D()
    {
        return show3D;
    }

    public void Fade3D()
    {
        if (show3D)
        {
            show3D = false;
        }
        else
        {
            show3D = true;
            whiteBG.SetActive(show3D);
            exitBtn3D.SetActive(show3D);
            zoomSlider.SetActive(show3D);
        }

        ReArrangeHirarchy3DView();
        Start3DSceneAnimations();
    }

    private void ReArrangeHirarchy3DView()
    {
        whiteBG.transform.SetAsLastSibling();
        modelTexture.transform.SetAsLastSibling();
        exitBtn3D.transform.SetAsLastSibling();
    }

    private void Start3DSceneAnimations()
    {
        whiteBG.GetComponent<Animator>().SetBool("show", show3D);
        modelTexture.GetComponent<Animator>().SetBool("show", show3D);
        zoomSlider.GetComponent<Animator>().SetBool("show", show3D);
        exitBtn3D.GetComponent<Animator>().SetBool("show", show3D);
    }

    public Quaternion GetCurRot()
    {
        return curRot;
    }

    public void SetCurRot(Quaternion rot)
    {
        this.curRot = rot;
    }

    public void StopRotationOnSlide()
    {
        camCtl.GetComponent<SimpleRotation>().disableInput();
        camCtl.GetComponent<SimpleRotation>().enableInput();
    }

    public int CheckVehicle()
    {
        return state.GetSelectedVehicle();
    }

    public int CheckSide()
    {
        return state.GetLoadedSide();
    }
    public int GetAnimModelArrayPos()
    {
        return animModelArrayPos;
    }

    public int GetStateInvisibleCountdown()
    {
        return state.GetInvisCountdown();
    }

    public int GetStateVisibleCountdown()
    {
        return state.GetVisCountdown();
    }

    public void GetCurrentRotation()
    {
        curRot = camCtl.transform.rotation;
        Debug.Log("curRot from VehicleScene" + curRot);
    }

    public Quaternion GetCurRotValue()
    {
        return curRot;
    }
}