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
    private string language = "ger";
    private string jsonString;
    private string path;
    [SerializeField] public GameObject basePlate;

    private void Awake()
    {
        InserText();
    }

    private void InserText()
    {
        path = Application.dataPath + "/Texts/rt/" + language + ".json";
        jsonString = File.ReadAllText(path);
        VehicleData vehicleData = JsonUtility.FromJson<VehicleData>(jsonString);

        title.text = vehicleData.title;
        year.text = vehicleData.year;
        descr.text = vehicleData.descr;

        ChangeBasePlateScale(vehicleData);
    }

    private void ChangeBasePlateScale(VehicleData vehicleData)
    {
        if (vehicleData.title == "MZ RT 125") // TODO clean this part of code
        {
            basePlate.transform.localScale = new Vector3(0.6f, 0.5f, 0.6f);
        }
    }

    public void SetLanguageEng()
    {
        language = "eng";
        InserText();
    }

    public void SetLanguageGer()
    {
        language = "ger";
        InserText();
    }
}
