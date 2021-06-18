using TMPro;
using UnityEngine;
#pragma warning disable CS0649 //suppress non relevant warnings

public class SceneControlText : MonoBehaviour
{
    //accessable members
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] TextMeshProUGUI descr;
    [SerializeField] GameObject descrPanel;

    //non-accessable members
    private SceneState state;
    private DataLoader loader;  //find loader-script

    private void Awake()
    {
        //all operations in here depent on DontDestroyOnLoad-Feature ()SceneState.cs --> Awake-Methode
        sceneLoader.CheckPreloadScene();
        state = FindObjectOfType<SceneState>();     //find state-script
        loader = FindObjectOfType<DataLoader>();    //find loader-script
    }

    private void Start()
    {
        state.SetCurScene();
        descrPanel.GetComponent<Animator>().SetBool("show", true);
        InserText();
    }

    public void InserText()
    {
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

    public void ClosingDelay()
    {
        descrPanel.GetComponent<Animator>().SetBool("show", false);
        Invoke("BackToVehicle", 2);
    }

    private void BackToVehicle()
    {
        sceneLoader.LoadVehicleScene();
    }
}
