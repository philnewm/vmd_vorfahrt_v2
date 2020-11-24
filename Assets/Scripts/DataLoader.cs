using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class DataLoader : MonoBehaviour
{
    //Input from outside
    [SerializeField] SceneState state;

    //memeber variables
    public Vehicle[] vehicles;
    string vehicleID;
    string curLanguage;

    private void Awake()
    {
        curLanguage = state.GetLanguage();
        int i = 0;
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
        FileInfo[] allFiles = directoryInfo.GetFiles("*.*");

        vehicles = new Vehicle[allFiles.Length];

        foreach (FileInfo file in allFiles)
        {
            SearchForContent(file, i);
            Debug.Log(file);
            i += 1;
        }
    }

    private void SearchForContent(FileInfo contentFile, int index)
    {
        //vehicle root directory
        DirectoryInfo subdirectoryInfo = new DirectoryInfo(contentFile.ToString());

        //ID found
        ExtractVehicleID(contentFile, index);

        SearchForText(index);
        SearchForTitlePic(index);
        //SearchForContentForModell();
        //SearchForTextures();
        //SearchForMagazine();
        //SearchForGallery();
        //WriteContentToClass();
    }

    private void ExtractVehicleID(FileInfo contentFile, int index)
    {
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(contentFile.ToString());
        vehicles[index] = new Vehicle(fileNameWithoutExtension, curLanguage);
        vehicleID = vehicles[index].GetName();
    }

    private void SearchForText(int index)
    {

        string languageGer = "ger", languageEng = "eng";

        LoadText(index, languageGer);
        LoadText(index, languageEng);
    }

    private void LoadText(int index, string language)
    {
        string jsonPath;
        string jsonString;
        jsonPath = Application.streamingAssetsPath + "/" + vehicleID + "/Text/" + language + ".json";
        jsonString = File.ReadAllText(jsonPath);
        vehicles[index].LoadText(jsonString);
    }

    private void SearchForTitlePic(int index)
    {
        
    }
}
