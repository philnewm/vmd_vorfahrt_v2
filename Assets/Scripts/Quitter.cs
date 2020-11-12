using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitter : MonoBehaviour
{
    public void quit()
    {
    if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        Application.Quit();
    }
}
