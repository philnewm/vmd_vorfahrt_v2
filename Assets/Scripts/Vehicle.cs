using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Vehicle
{
    [Header("Vehicle ID")]
    [SerializeField] string name;
    [SerializeField] string year;
    [SerializeField] string title;

    [Header("German Text")]
    [SerializeField] string gerHeader;
    [TextArea(10,3)] [SerializeField] string gerPreDescr;
    [TextArea(10,8)] [SerializeField] string gerDescr;

    [Header("English Text")]
    [SerializeField] string engHeader;
    [TextArea(10, 3)] [SerializeField] string engPreDescr;
    [TextArea(10, 8)] [SerializeField] string engDescr;

    [Header("Title Picture")]
    [SerializeField] Texture2D titlePicture;

    [Header("Content for 3D Modells")]
    [SerializeField] GameObject vehicleModel;
    [SerializeField] Material opaqueMat;
    [SerializeField] Material transpMat;

    [SerializeField] public List<Texture2D> magazine;
    [SerializeField] public List<Texture2D> gallery;

    private SceneState state;

    public Vehicle(string name)
    {
        this.name = name;
        magazine = new List<Texture2D>();
        gallery = new List<Texture2D>();
    }

    public void LoadText (string jsonData)
    {
        JsonUtility.FromJsonOverwrite(jsonData, this);
    }

    public string GetName()
    {
        return name;
    }

    public string GetTitle()
    {
        return title;
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

    public void SetTitlePic(Texture2D titlePic)
    {
        this.titlePicture = titlePic;
    }

    public void SetTitlePicName(string titlePicName)
    {
        this.titlePicture.name= titlePicName;
    }

    public void SetGallery(List<Texture2D> gallery)
    {
        this.gallery = gallery;
    }

    public List<Texture2D> GetGallery()
    {
        return gallery;
    }

    public void SetMagazine(List<Texture2D> magazine)
    {
        this.magazine = magazine;
    }

    public void SetMagazine(Texture2D magazine)
    {
        this.magazine.Add(magazine);
    }

    public void SetMagazinePosition(int magPos, string name)
    {
        int newPos = this.magazine.Count - 1;
        this.magazine[newPos].name = name;
    }

    public List<Texture2D> GetMagazine()
    {
        return magazine;
    }

    public Texture2D GetMagazine(int index)
    {
        return magazine[index];
    }
}
