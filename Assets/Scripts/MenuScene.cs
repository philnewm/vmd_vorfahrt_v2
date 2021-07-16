using System;
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

    [Header("Scroll Menu")]
    [SerializeField] GameObject scrollPanel;
    [SerializeField] GameObject btnPrefab;
    [SerializeField] GameObject[] menuEntries;

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
        CreateMenuEntries();
    }

    private void CreateMenuEntries()
    {
        menuEntries = new GameObject[loader.vehicles.Length];
        for (int index = 0; index <= menuEntries.Length - 1; index++)
        {
            menuEntries[index] = Instantiate(btnPrefab, scrollPanel.transform);
            menuEntries[index].GetComponent<RawImage>().texture = loader.vehicles[index].GetTitlePic();

            int curValue = index; //otherwise wont work

            menuEntries[index].GetComponent<Button>().onClick.AddListener(() => { state.SetSelectedVehicle(curValue); sceneLoader.LoadVehicleScene(); });
            menuEntries[index].GetComponent<MenuEntry>().Setname(loader.vehicles[index].GetTitle());
            menuEntries[index].GetComponent<MenuEntry>().SetYear(loader.vehicles[index].GetYear());
        }
    }

    public void SwitchVehicle(int num)
    {
        state.SetSelectedVehicle(num);
    }
}
