using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

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
        CheckIfExists();

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

    private void CheckIfExists()
    {
        int DataLoaderCount = FindObjectsOfType<DataLoader>().Length;
        if (DataLoaderCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
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
        string filePath;
        string[] titlePicPath;
        //Create an array of file paths from which to choose
        filePath = Application.streamingAssetsPath + "/" + vehicleID + "/Images/";  //Get path of folder
        titlePicPath = Directory.GetFiles(filePath, "*titlePic.png"); // Get all files of type .png in this folder

        //Converts desired path into byte array
        byte[] pngBytes = System.IO.File.ReadAllBytes(titlePicPath[0]);
        Debug.Log(titlePicPath[0]);

        //Creates texture and loads byte array data to create image
        Texture2D tex = new Texture2D(2560, 1440);
        tex.LoadImage(pngBytes);

        //Creates a new Sprite based on the Texture2D
        Sprite titlePicSprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

        //Assigns the UI sprite
        vehicles[index].SetTitlePic(titlePicSprite);
    }
}
