using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl3D : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;

    private void Awake()
    {
        sceneLoader.CheckPreloadScene();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
