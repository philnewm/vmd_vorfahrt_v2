using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.Networking;
using System.Linq;
#pragma warning disable CS0649 //suppress non relevant warnings

public class DataLoader : MonoBehaviour
{
    //Input from outside
    [SerializeField] SceneState state;
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] string titlePic;
    [SerializeField] string imagesSubFolder;
    [SerializeField] string imagesUWRSubfolder;
    [SerializeField] string magazineFileFormat;
    [SerializeField] string TextSubFolder;
    public string[] vehicleDirNames;
    public string[] availableLanguages;
    public string textFormat;

    //member variables
    public Vehicle[] vehicles;
    private List<Texture2D> magazine;
    private FileInfo[] magFiles;
    private DirectoryInfo streamingAssetsDir;
    private string vehicleIDUWR;
    private string magUWRPath;
    private string vehicleIDSearch;
    private string jsonPath;
    private DirectoryInfo magDirSearchPath;

    private void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        //get streamingAssets path
        streamingAssetsDir = new DirectoryInfo(Application.streamingAssetsPath);
        GetAvailableVehicles();
        LoopThroughAvailableVehicles();
    }

    private void CreateMagFileArray()
    {
        magFiles = magDirSearchPath.GetFiles("*.jpg");
    }

    private void GetAvailableVehicles()
    {
        //FileInfo[] availableVehicles = streamingAssetsDir.GetFiles("*.*"); //wont work outside editor
        vehicles = new Vehicle[vehicleDirNames.Length];
    }

    private void LoopThroughAvailableVehicles()
    {
        for(int i = 0; i <= vehicles.Length-1; i++)
        {
            //ID found
            CrateVehicle(i);
            ExtractVehicleID(i);
            CreatePaths();
            CreateMagFileArray();
            SearchForContent(i);
            //Debug.Log(file);
        }
    }

    private void CrateVehicle(int index)
    {
        vehicles[index] = new Vehicle(vehicleDirNames[index]);
    }

    private void ExtractVehicleID(int index)
    {
        //string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(contentFile.ToString()); //wont work outside editor
        //vehicles[0] = new Vehicle(fileNameWithoutExtension);
        vehicleIDSearch = "/" + vehicleDirNames[index];
        vehicleIDUWR = "/" + vehicleDirNames[index];
    }

    private void CreatePaths()
    {
        magUWRPath = Path.Combine("file://" + streamingAssetsDir + vehicleIDUWR + imagesUWRSubfolder);
        magDirSearchPath = new DirectoryInfo(streamingAssetsDir + vehicleIDSearch + imagesSubFolder);
        jsonPath = Path.Combine("file://" + streamingAssetsDir + vehicleIDUWR + TextSubFolder);
        //Debug.Log(magDirSearchPath);
    }

    private void SearchForContent(int index)
    {
        //SearchForText(index);
        foreach (FileInfo image in magFiles)
        {
            string fileName = Path.GetFileName(image.ToString());
            StartCoroutine(LoadMagImages(fileName, index));
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
        string jsonPath;
        string jsonString;
        jsonPath = Application.streamingAssetsPath + "/" + vehicleIDSearch + "/Text/" + language + ".json";
        jsonString = File.ReadAllText(jsonPath);
        vehicles[index].LoadText(jsonString);
    }

    private IEnumerator LoadJSONFiles(int index, string language)
    {
        string searchForJSON = jsonPath + language + textFormat;

        using (UnityWebRequest uwr = UnityWebRequest.Get(searchForJSON))
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
        Debug.Log("Durchlauf: " + index);
        string searchForJSON = jsonPath + language + textFormat;
        Debug.Log("final search path: " + searchForJSON);

        using (UnityWebRequest uwr = UnityWebRequest.Get(searchForJSON))
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

    private IEnumerator LoadMagImages(string file, int index)
    {
        string searchForMag = magUWRPath + file;
        //Debug.Log(searchForMag);

        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(searchForMag))
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
                vehicles[index].magazine.Add(DownloadHandlerTexture.GetContent(uwr));
                vehicles[index].magazine[vehicles[index].magazine.Count - 1].name = Path.GetFileNameWithoutExtension(file);
            }
        }
    }

    private void SortMagList(int index)
    {
        //sorts the random list by item name
        vehicles[index].magazine = vehicles[index].magazine.OrderBy(mag => mag.name, new AlphanumComparatorFast()).ToList();        
    }

    //AlphanumComparatorFast made by dotnetperls
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
        string searchForTitlePic = magUWRPath + titlePic;
        //Debug.Log(searchForMag);

        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(searchForTitlePic))
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
                vehicles[index].SetTitlePicName(Path.GetFileNameWithoutExtension(titlePic));
            }
        }
    }

    private IEnumerator Start()
    {
        for(int i = 0; i <= vehicleDirNames.Length-1; i++)
        {
            SortMagList(i);
        }

        yield return new WaitForSeconds(1);
        sceneLoader.LoadNextScene();
    }
}
