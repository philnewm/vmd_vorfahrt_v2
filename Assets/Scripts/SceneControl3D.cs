using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl3D : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] GameObject rt, rl;
    [SerializeField] GameObject modellAsTexture;
    [SerializeField] GameObject driverDoorBtn, coDriverDoorBtn, engineCoverBtn;
    private SceneState state;

    private void Awake()
    {
        sceneLoader.CheckPreloadScene();

        state = FindObjectOfType<SceneState>();
    }

    private void Start()
    {
        state.SetCurScene();
        CheckVehicleID();
        modellAsTexture.GetComponent<Animator>().SetBool("upscaled", true);
    }

    private void CheckVehicleID()
    {
        if (state.GetSelectedVehicle() == 0) //check wich vehicle to display, value found in state-class
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
