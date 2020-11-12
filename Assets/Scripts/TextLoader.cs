using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class TextLoader : MonoBehaviour
{
    //params
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI year;
    [SerializeField] TextMeshProUGUI descr;

    //member variables
    private string jsonString;
    private string path;

    private void Awake()
    {
        path = Application.dataPath + "/Texts/rt/ger.json";
        jsonString = File.ReadAllText(path);
        VehicleData rt = JsonUtility.FromJson<VehicleData>(jsonString);

        title.text = "Bezeichnung: " + rt.title;
        year.text = "Erscheinungsjahr: " + rt.year;
        descr.text = rt.descr;


    }
}
