using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Linq;
//#pragma warning disable CS0649 //suppress non relevant warnings

public class DataLoader : MonoBehaviour
{
    //Input from outside
    [Header("External Scripts")]
    [Tooltip("load SceneState-Script from another gameObject")]
    [SerializeField] SceneState state;
    [Tooltip("load SceneLoader-Script from another gameObject")]
    [SerializeField] SceneLoader sceneLoader;

    [Header("Files and File Paths")]
    [Tooltip("insert the exact filename of the title picture, needs to be consistent")]
    [SerializeField] string titlePicFileName;
    [Tooltip("insert the exact directory name for the gallery image subdirectory, needs '/' before and after it")]
    [SerializeField] string galleryImgSubDir;
    [Tooltip("insert the exact directory name for the text subdirectory, needs '/' before and after it")]
    [SerializeField] string textSubDir;
    //string imagesSubFolder;  seems obsolete
    //string magazineFileFormat; seems obsolete

    [Header("For Debugging")]
    [SerializeField]
    bool moveon;
    [Tooltip("how many are available and what are their values")]
    [SerializeField]
    public string[] availableVehicles, availableLanguages;
    public string textFileFormat;

    [Header("UWR realted")]
    [Tooltip("Prefix for UWRs to access local file system")]
    [SerializeField]
    private string uwrLocalPath;

    //member variables
    public Vehicle[] vehicles;
    private FileInfo[] galImgFiles;
    private DirectoryInfo streamingAssetsDir;
    private string magUWRPath, jsonPath;

    private void Awake()
    {
        uwrLocalPath = "file://";
        LoadStreamingAssetsDir();
        CreateVehicleArray();
        LoopThroughAvailableVehicles();
    }

    private void LoadStreamingAssetsDir()
    {
         streamingAssetsDir = new DirectoryInfo(Application.streamingAssetsPath);  //save streamingAssets path
    }

    private void CreateVehicleArray()
    {
        FileInfo[] Vehicles = streamingAssetsDir.GetFiles("*.*"); //wont work outside editor
        vehicles = new Vehicle[availableVehicles.Length]; //try to adjust to work dynamic like it did in line above
    }

    private void LoopThroughAvailableVehicles()
    {
        for(int i = 0; i <= vehicles.Length-1; i++)
        {
            CrateVehicle(i);
            //ExtractVehicleID(i);
            CreatePaths(i);
            CreateGalFileArray();
            SearchForContent(i);
            //Debug.Log(file);
        }
    }

    private void CrateVehicle(int index)
    {
        vehicles[index] = new Vehicle(availableVehicles[index]);
    }

    private void ExtractVehicleID(int index)
    {
        //string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(contentFile.ToString()); //wont work outside editor
        //vehicles[0] = new Vehicle(fileNameWithoutExtension);
    }

    private void CreatePaths(int index)
    {
        string vehiclePath = streamingAssetsDir + "/" + availableVehicles[index];

        magUWRPath = Path.Combine(vehiclePath + "/" + galleryImgSubDir + "/");
        jsonPath = Path.Combine(vehiclePath + "/" + textSubDir + "/");
    }

    private void CreateGalFileArray()
    {
        DirectoryInfo galImgSearchPath = new DirectoryInfo(magUWRPath);
        galImgFiles = galImgSearchPath.GetFiles("*.jpg");
    }

    private void SearchForContent(int index)
    {
        //SearchForText(index);
        foreach (FileInfo image in galImgFiles)
        {
            string fileName = Path.GetFileName(image.ToString());
            StartCoroutine(LoadGalImg(fileName, index));
            //SearchForGallery();
        }

        foreach (string language in availableLanguages)
        {
            StartCoroutine(LoadJSONFiles(index, language));
        }
        //LoadSingleJSONFiles(0, "eng");

        StartCoroutine(LoadTitlePic(index));
        //StartCoroutine(LoadJSONFiles(0, "ger"));
        //SearchForContentForModel(index);
        //SearchForTextures();
    }

    private void SearchForText(int index)
    {
        string languageger = "ger", languageeng = "eng";

        LoadText(index, languageger);
        LoadText(index, languageeng);
    }

    private void LoadText(int index, string language)
    {
        string jsonFile;
        string jsonString;

        jsonFile = jsonPath + language + textFileFormat;
        jsonString = File.ReadAllText(jsonPath);
        vehicles[index].LoadText(jsonString);
    }

    private IEnumerator LoadJSONFiles(int index, string language)
    {
        string searchForJSON = jsonPath + language + textFileFormat;

        using (UnityWebRequest uwr = UnityWebRequest.Get(uwrLocalPath + searchForJSON))
        {
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                vehicles[index].LoadText(uwr.downloadHandler.text);
            }
        }
    }

    private IEnumerator LoadSingleJSONFiles(int index, string language)
    {
        string searchForJSON = jsonPath + language + textFileFormat;

        using (UnityWebRequest uwr = UnityWebRequest.Get(uwrLocalPath + searchForJSON))
        {
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                //Debug.Log(jsonData);
                vehicles[index].LoadText(uwr.downloadHandler.text);
            }
        }
    }

    private IEnumerator LoadGalImg(string file, int index)
    {
        string searchForMag = magUWRPath + file;
        //Debug.Log(searchForMag);

        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(uwrLocalPath + searchForMag))
        {
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                //Debug.Log(vehicles[index].GetName());
                //adds images in random way to list
                vehicles[index].gallery.Add(DownloadHandlerTexture.GetContent(uwr));
                vehicles[index].gallery[vehicles[index].gallery.Count - 1].name = Path.GetFileNameWithoutExtension(file);
            }
        }
    }

    private void SortMagList(int index)
    {
        //sorts the random list by item name
        vehicles[index].gallery = vehicles[index].gallery.OrderBy(mag => mag.name, new AlphanumComparatorFast()).ToList();        
    }

    // NOTE: This code is free to use in any program.
	// ... It was developed by Dot Net Perls.
    //link: https://www.dotnetperls.com/alphanumeric-sorting
    public class AlphanumComparatorFast : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string s1 = x as string;
            if (s1 == null)
            {
                return 0;
            }
            string s2 = y as string;
            if (s2 == null)
            {
                return 0;
            }

            int len1 = s1.Length;
            int len2 = s2.Length;
            int marker1 = 0;
            int marker2 = 0;

            // Walk through two the strings with two markers.
            while (marker1 < len1 && marker2 < len2)
            {
                char ch1 = s1[marker1];
                char ch2 = s2[marker2];

                // Some buffers we can build up characters in for each chunk.
                char[] space1 = new char[len1];
                int loc1 = 0;
                char[] space2 = new char[len2];
                int loc2 = 0;

                // Walk through all following characters that are digits or
                // characters in BOTH strings starting at the appropriate marker.
                // Collect char arrays.
                do
                {
                    space1[loc1++] = ch1;
                    marker1++;

                    if (marker1 < len1)
                    {
                        ch1 = s1[marker1];
                    }
                    else
                    {
                        break;
                    }
                } while (char.IsDigit(ch1) == char.IsDigit(space1[0]));

                do
                {
                    space2[loc2++] = ch2;
                    marker2++;

                    if (marker2 < len2)
                    {
                        ch2 = s2[marker2];
                    }
                    else
                    {
                        break;
                    }
                } while (char.IsDigit(ch2) == char.IsDigit(space2[0]));

                // If we have collected numbers, compare them numerically.
                // Otherwise, if we have strings, compare them alphabetically.
                string str1 = new string(space1);
                string str2 = new string(space2);

                int result;

                if (char.IsDigit(space1[0]) && char.IsDigit(space2[0]))
                {
                    int thisNumericChunk = int.Parse(str1);
                    int thatNumericChunk = int.Parse(str2);
                    result = thisNumericChunk.CompareTo(thatNumericChunk);
                }
                else
                {
                    result = str1.CompareTo(str2);
                }

                if (result != 0)
                {
                    return result;
                }
            }
            return len1 - len2;
        }
    }

    private IEnumerator LoadTitlePic(int index)
    {
        string searchForTitlePic = magUWRPath + titlePicFileName;
        //Debug.Log(searchForMag);

        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(uwrLocalPath + searchForTitlePic))
        {
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                //Debug.Log(vehicles[index].GetName());
                //adds images in random way to list
                vehicles[index].SetTitlePic(DownloadHandlerTexture.GetContent(uwr));
                vehicles[index].SetTitlePicName(Path.GetFileNameWithoutExtension(titlePicFileName));
            }
        }
    }

    private IEnumerator Start()
    {
        for(int i = 0; i <= availableVehicles.Length-1; i++)
        {
            SortMagList(i);
        }

        if (moveon)
        {
            yield return new WaitForSeconds(1);
            sceneLoader.LoadNextScene();
        }        
    }
}
