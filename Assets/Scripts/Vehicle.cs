using UnityEngine;
using System.Collections.Generic;
#pragma warning disable CS0649 //suppress non relevant warnings

[System.Serializable]
public class Vehicle
{
    [Header("Vehicle ID")]
    [SerializeField] string name;
    [SerializeField] string year;

    [Header("German Text")]
    [SerializeField] string gerTitle;
    [SerializeField] string gerHeader;
    [TextArea(10, 3)] [SerializeField] string gerPreDescr;
    [TextArea(10, 8)] [SerializeField] string gerDescr;

    [Header("English Text")]
    [SerializeField] string engTitle;
    [SerializeField] public string engHeader;
    [TextArea(10, 3)] [SerializeField] string engPreDescr;
    [TextArea(10, 8)] [SerializeField] string engDescr;

    [Header("Title Picture")]
    [SerializeField] Texture2D titlePicture;
    [SerializeField] public List<Texture2D> gallery;

    [Header("Content for 3D Model")]
    [SerializeField] GameObject vehicleModel;


    public Vehicle(string name)
    {
        this.name = name;
        gallery = new List<Texture2D>();
    }

    public void LoadText(string jsonData)
    {
        JsonUtility.FromJsonOverwrite(jsonData, this);
    }

    public string GetName()
    {
        return name;
    }

    public string GetGerTitle()
    {
        return gerTitle;
    }

    public string GetEngTitle()
    {
        return engTitle;
    }

    public string GetYear()
    {
        return year;
    }

    public string GetGerHeader()
    {
        return gerHeader;
    }

    public string GetEngHeader()
    {
        return engHeader;
    }

    public string GetGerPreDescr()
    {
        return gerPreDescr;
    }

    public string GetEngPreDescr()
    {
        return engPreDescr;
    }

    public string GetGerDescr()
    {
        return gerDescr;
    }

    public string GetEngDescr()
    {
        return engDescr;
    }

    public Texture2D GetTitlePic()
    {
        return titlePicture;
    }

    public void SetTitlePic(Texture2D titlePic, string titlePicName)
    {
        this.titlePicture = titlePic;
        this.titlePicture.name = titlePicName;
    }


    public void SetGallery(Texture2D loadedGallery, string vehicleName)
    {
        this.gallery.Add(loadedGallery);
        this.gallery[gallery.Count - 1].name = vehicleName;
    }

    public List<Texture2D> GetGallery()
    {
        return gallery;
    }

    public Texture2D GetGallery(int index)
    {
        return gallery[index];
    }

    public void Set3DModel(GameObject vehiclePrefFab)
    {
        this.vehicleModel = vehiclePrefFab;
    }

    public GameObject Get3DModel()
    {
        return this.vehicleModel;
    }
}
