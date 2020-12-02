using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.Networking;

public class DataLoader : MonoBehaviour
{
    //Input from outside
    [SerializeField] SceneState state;

    //member variables
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
            //Debug.Log(file);
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
        SearchImages(index);
        //SearchForContentForModel(index);
        //SearchForTextures();
        //StartCoroutine("SearchForMagazine", index);
        //SearchForGallery();
    }

    private void ExtractVehicleID(FileInfo contentFile, int index)
    {
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(contentFile.ToString());
        vehicles[index] = new Vehicle(fileNameWithoutExtension);
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

    private void SearchImages(int index) //maybe combine both image loaders
    {
        string filePath;
        string[] titlePicPath;
        string[] magPath;


        //path to vehicle directory
        filePath = Application.streamingAssetsPath + "/" + vehicleID + "/Images/";  //Get path of folder

        //path to titlepic
        titlePicPath = Directory.GetFiles(filePath, "*titlePic.png"); // Get all files of type .png in this folder

        //path to mag
        magPath = Directory.GetFiles(filePath, "*_mag.jpg");

        SearchMagPics(index, magPath);

        SearchTitlePic(index, titlePicPath);
    }

    private void SearchTitlePic(int index, string[] titlePicPath)
    {
        //Converts titlepic path into byte array
        byte[] pngBytes = System.IO.File.ReadAllBytes(titlePicPath[0]);

        Texture2D tex = new Texture2D(1024, 1024);
        tex.LoadImage(pngBytes);

        //Creates a new Sprite based on the Texture2D
        Sprite titlePicSprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

        //assign titlepic to loaded vehicle instance
        vehicles[index].SetTitlePic(titlePicSprite);
    }

    private void SearchMagPics(int index, string[] magPath)
    {
        Sprite[] magSprite = new Sprite[magPath.Length];

        for (int i = 0; i <= magPath.Length - 1; i++)
        {
            //Converts magpic path into byte array
            byte[] pngBytes = System.IO.File.ReadAllBytes(magPath[i]);

            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(pngBytes); // texture from byte array

            //new sprite for each texture
            magSprite[i] = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
        //assign magpics to loaded vehicle instance
        vehicles[index].SetMagazine(magSprite);
    }

    private void SearchForMagazine(int index)
    {
        string filePath;
        string[] magPath;

        filePath = Application.streamingAssetsPath + "/" + vehicleID + "/Images/";
        magPath = Directory.GetFiles(filePath, "*_mag.jpg");

        Sprite[] magSprite = new Sprite[magPath.Length];

        for (int i = 0; i <= magPath.Length-1; i++)
        {
            byte[] pngBytes = System.IO.File.ReadAllBytes(magPath[i]);

            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(pngBytes);

            magSprite[i] = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
        vehicles[index].SetMagazine(magSprite);
    }
}
