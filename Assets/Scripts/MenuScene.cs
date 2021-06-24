using TMPro;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable CS0649 //suppress non-relevant warnings

public class MenuScene : MonoBehaviour
{
    //accessable members
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

    //non-accessable members
    private SceneState state;
    private DataLoader loader;

    private void Awake()
    {
        //all operations in here depent on DontDestroyOnLoad-Feature ()SceneState.cs --> Awake-Methode
        sceneLoader.CheckPreloadScene();
        state = FindObjectOfType<SceneState>(); //find state-script 
        loader = FindObjectOfType<DataLoader>(); //find loader-script
    }

    private void Start()
    {
        state.SetCurScene(); //update scene index

        //populate scene
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

    public void SwitchVehicle(int num)
    {
        state.SetSelectedVehicle(num);
    }
}
