using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using System.Linq;
//#pragma warning disable CS0649 //suppress non relevant warnings

public class DataLoader : MonoBehaviour
{
    //accessable members
    [Header("External Scripts")]
    [Tooltip("load SceneState-Script from another gameObject")]
    [SerializeField] SceneState state;
    [Tooltip("load SceneLoader-Script from another gameObject")]
    [SerializeField] SceneLoader sceneLoader;

    [Header("Files and File Paths")]
    [Tooltip("insert the exact filename of the settings-file, needs to be consistent")]
    [SerializeField] string settingsFileName;
    [Tooltip("insert the exact filename of the title picture, needs to be consistent")]
    [SerializeField] string titlePicFileName;
    [Tooltip("insert the exact directory name for the gallery image subdirectory, needs '/' before and after it")]
    [SerializeField] string galleryImgSubDir;
    [Tooltip("insert the exact directory name for the text subdirectory, needs '/' before and after it")]
    [SerializeField] string textSubDir;

    [SerializeField] string prefabDir;

    [Header("For Debugging")]
    [SerializeField]
    bool moveon;
    [Tooltip("how many are available and what are their values")]
    [SerializeField]
    public string[] leftVehicles, rightVehicles, availableVehicles, availableLanguages;
    public string textFileFormat;

    [Header("UWR realted")]
    [Tooltip("Prefix for UWRs to access local file system")]
    [SerializeField]
    private string uwrLocalPath;

    [Header("3D Models")]
    [Tooltip("drag'n'drop to extent list")]
    [SerializeField]
    private GameObject[] modelList;

    //member variables
    public Vehicle[] vehicles;

    //non-accessable members
    private FileInfo[] galImgFiles;
    private DirectoryInfo streamingAssetsDir;
    private string magUWRPath, jsonPath;

    private void Awake()
    {
        uwrLocalPath = "file://";
        LoadStreamingAssetsDir();
        LoadSettingsFile();
        LoadSide();
        CreateVehicleArray();
        CreateModelList();
        if (availableVehicles.Length != 0)
        {
            LoopThroughAvailableVehicles();
        }
    }

    private void LoadStreamingAssetsDir()
    {
        streamingAssetsDir = new DirectoryInfo(Application.streamingAssetsPath);  //save streamingAssets path
    }

    private void LoadSettingsFile()
    {
        string settingsJSON = uwrLocalPath + streamingAssetsDir + "/" + settingsFileName + textFileFormat;

        using (UnityWebRequest uwr = UnityWebRequest.Get(settingsJSON))
        {
            uwr.SendWebRequest();
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                state.SetSelectedSide(uwr.downloadHandler.text);
            }
        }
    }

    private void LoadSide()
    {
        if (state.GetLoadedSide() == 1)
        {
            availableVehicles = new string[rightVehicles.Length];
            for (int index = 0; index <= availableVehicles.Length - 1; index++)
            {
                availableVehicles[index] = rightVehicles[index];
            }
        }
        else
        {
            availableVehicles = new string[leftVehicles.Length];
            for (int index = 0; index <= availableVehicles.Length - 1; index++)
            {
                availableVehicles[index] = leftVehicles[index];
            }
        }
    }

    private void CreateVehicleArray()
    {
        FileInfo[] Vehicles = streamingAssetsDir.GetFiles("*.*"); //wont work outside editor
        vehicles = new Vehicle[availableVehicles.Length]; //try to adjust to work dynamic like it did in line above
    }

    private void CreateModelList()
    {
        string modelPath = prefabDir + "/" + state.GetSelectedSide() + "/";
        modelList = new GameObject[Resources.LoadAll<GameObject>(modelPath).Length];
        modelList = Resources.LoadAll<GameObject>(modelPath);
    }

    private void LoopThroughAvailableVehicles()
    {
        for (int i = 0; i <= vehicles.Length - 1; i++)
        {
            CrateVehicle(i);
            CreatePaths(i);
            CreateGalFileArray();
            SearchForContent(i);
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
        string vehiclePath = streamingAssetsDir + "/" + state.GetSelectedSide() + "/" + availableVehicles[index];

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
        foreach (FileInfo image in galImgFiles)
        {
            string fileName = Path.GetFileName(image.ToString());
            StartCoroutine(LoadGalImg(fileName, index));
        }

        foreach (string language in availableLanguages)
        {
            StartCoroutine(LoadJSONFiles(index, language));
        }

        StartCoroutine(LoadTitlePic(index));
        LoadModelPrefab(index);
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

    private IEnumerator LoadGalImg(string file, int index)
    {
        string searchForMag = magUWRPath + file;

        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(uwrLocalPath + searchForMag))
        {
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                //ads image files in random order to list
                vehicles[index].SetGallery(DownloadHandlerTexture.GetContent(uwr), Path.GetFileNameWithoutExtension(file));
            }
        }
    }

    private void SortGalList(int index)
    {
        //sorts the random list by item name
        vehicles[index].gallery = vehicles[index].gallery.OrderBy(mag => mag.name, new AlphanumComparatorFast()).ToList();
    }

    private IEnumerator LoadTitlePic(int index)
    {
        string searchForTitlePic = magUWRPath + titlePicFileName;

        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(uwrLocalPath + searchForTitlePic))
        {
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                vehicles[index].SetTitlePic(DownloadHandlerTexture.GetContent(uwr), titlePicFileName);
            }
        }
    }

    private void LoadModelPrefab(int index)
    {
        vehicles[index].Set3DModel(modelList[index]);
    }

    private IEnumerator Start()
    {
        for (int i = 0; i <= availableVehicles.Length - 1; i++)
        {
            SortGalList(i);
        }

        if (moveon)
        {
            yield return new WaitForSeconds(1);
            sceneLoader.LoadNextScene();
        }
    }
}
