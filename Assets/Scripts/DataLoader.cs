using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataLoader : MonoBehaviour
{
    public Vehicle[] vehicles;

    private void Start()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
        Debug.Log("Streaming Assets Path: " + Application.streamingAssetsPath);
        FileInfo[] allFiles = directoryInfo.GetFiles("*.*");

        vehicles = new Vehicle[allFiles.Length];

        Debug.Log(allFiles.Length + " files found: " + allFiles[0].Name + ", " + allFiles[1].Name);

        foreach (FileInfo file in allFiles)
        {
            StartCoroutine("SearchForContent", file);
        }
    }

    private void SearchForContent(FileInfo contentFile)
    {
        DirectoryInfo subdirectoryInfo = new DirectoryInfo(contentFile.ToString());
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(contentFile.ToString());
        Debug.Log(contentFile.ToString());

        vehicles[0] = new Vehicle(fileNameWithoutExtension);
    }
}
