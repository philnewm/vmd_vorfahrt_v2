using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable CS0649

public class SceneControl3D : MonoBehaviour
{
    //accessable members
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] GameObject rt, rl;
    [SerializeField] GameObject modellAsTexture;
    [SerializeField] GameObject driverDoorBtn, coDriverDoorBtn, engineCoverBtn;

    //non-accessable members
    private SceneState state;

    private void Awake()
    {
        //all operations in here depent on DontDestroyOnLoad-Feature ()SceneState.cs --> Awake-Methode
        sceneLoader.CheckPreloadScene();
        state = FindObjectOfType<SceneState>(); //find state-script
    }

    private void Start()
    {
        state.SetCurScene();    //update scene index
        CheckVehicleID();
        modellAsTexture.GetComponent<Animator>().SetBool("upscaled", true);
    }

    private void CheckVehicleID()
    {
        if (state.GetSelectedVehicle() == 0) //check which vehicle to display, value found in state-class
        {
            rt.SetActive(false);
            rl.SetActive(true);
            driverDoorBtn.SetActive(true);
            coDriverDoorBtn.SetActive(true);
            engineCoverBtn.SetActive(true);
        }
        else
        {
            rt.SetActive(true);
            rl.SetActive(false);
            driverDoorBtn.SetActive(false);
            coDriverDoorBtn.SetActive(false);
            engineCoverBtn.SetActive(false);
        }
    }
    public void ClosingDelay()
    {
        modellAsTexture.GetComponent<Animator>().SetBool("upscaled", false);
        Invoke("BackToVehicle", 2);
    }

    private void BackToVehicle()
    {
        sceneLoader.LoadVehicleScene();
    }
}
