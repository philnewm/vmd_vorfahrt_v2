using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.Networking;
using System.Linq;

public class DataLoader : MonoBehaviour
{
    //Input from outside
    [SerializeField] SceneState state;
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] string imagesSubFolder;
    [SerializeField] string imagesUWRSubfolder;
    [SerializeField] string magazineFileFormat;
    [SerializeField] string titlePicFileFormat;
    [SerializeField] string TextSubFolder;
    [SerializeField] string textUWRSubFolder;
    public string[] vehicleDirNames;
    public List<Texture2D> magazine;

    //member variables
    public Vehicle[] vehicles;
    private FileInfo[] magFiles;
    private DirectoryInfo streamingAssetsDir;
    private string magUWRPath;
    private string vehicleID;
    private DirectoryInfo magDirSearchPath;

    private void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        //get streamingAssets path
        streamingAssetsDir = new DirectoryInfo(Application.streamingAssetsPath);
        GetAvailableVehicles();
        magazine = new List<Texture2D>(); //init Texture2D list here to be used in LoadImages
        LoopThroughAvailableVehicles();
    }

    private void CreateMagFileArray()
    {
        magFiles = magDirSearchPath.GetFiles("*.jpg");
    }

    private void GetAvailableVehicles()
    {
        FileInfo[] availableVehicles = streamingAssetsDir.GetFiles("*.*"); //wont work outside editor
        vehicles = new Vehicle[vehicleDirNames.Length];
    }

    private void LoopThroughAvailableVehicles()
    {
        for(int i = 0; i <= vehicles.Length-1; i++)
        {
            //ID found
            ExtractVehicleID(i);
            CreatePaths(vehicleID);
            CreateMagFileArray();
            SearchForContent(i);
            //Debug.Log(file);
        }
    }

    private void ExtractVehicleID(int index)
    {
        //string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(contentFile.ToString()); //wont work outside editor
        //vehicles[0] = new Vehicle(fileNameWithoutExtension);
        vehicleID = "\\" + vehicleDirNames[index];
    }

    private void CreatePaths(string vehicleID)
    {
        magUWRPath = Path.Combine("file://" + streamingAssetsDir + vehicleID + imagesSubFolder);
        magDirSearchPath = new DirectoryInfo(streamingAssetsDir + vehicleID + imagesSubFolder);
    }

    private void SearchForContent(int index)
    {
        //SearchForText(index);

        foreach (FileInfo image in magFiles)
        {
            string fileName = Path.GetFileName(image.ToString());
            Debug.Log(fileName);
            StartCoroutine(LoadMagImages(fileName, index));
        }
        //SearchImages(index);
        //SearchForContentForModel(index);
        //SearchForTextures();
        //SearchForGallery();
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

    private IEnumerator LoadMagImages(string file, int index)
    {
        string searchForMag = magUWRPath + file;

        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(searchForMag))
        {
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {   //adds images in random way to list
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

    private void Start()
    {
        for(int i = 0; i <= vehicleDirNames.Length-1; i++)
        {
            SortMagList(i);
        }
        sceneLoader.LoadNextScene();
    }
}
