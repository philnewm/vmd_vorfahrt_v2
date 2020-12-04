using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl3D : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] GameObject rt, rl;
    private SceneState state;

    private void Awake()
    {
        sceneLoader.CheckPreloadScene();

        state = FindObjectOfType<SceneState>();
        state.SetCurScene();
    }

    private void Start()
    {
        CheckVehicleID();
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
}
