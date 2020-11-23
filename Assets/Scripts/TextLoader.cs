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
    [SerializeField] SceneState state;
    [SerializeField] DataLoader dataloader;

    [SerializeField] public GameObject basePlate;

    //member variables
    private string jsonString;
    private string path;
    private Vehicle[] vehicle;

    private void Awake()
    {
        //InserText();
    }

    private void Start()
    {
        title.text = dataloader.vehicles[0].GetName();
    }

    private void InserText()
    {
        path = Application.dataPath + "/Texts/rt/" + state.GetLanguage() + ".json";
        jsonString = File.ReadAllText(path);
        TextData textData = JsonUtility.FromJson<TextData>(jsonString);


        //title.text = textData.title;
        //year.text = textData.year;
        //descr.text = textData.descr;
    }

    public void SetLanguageEng()
    {
        state.SetLanguage("eng");
        InserText();
    }

    public void SetLanguageGer()
    {
        state.SetLanguage("ger");
        InserText();
    }
}
