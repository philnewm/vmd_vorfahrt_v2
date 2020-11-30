using UnityEngine;
using System.Collections;

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
    [SerializeField] Sprite titlePicture;

    [Header("Content for 3D Modells")]
    [SerializeField] GameObject vehicleModel;
    [SerializeField] Material opaqueMat;
    [SerializeField] Material transpMat;

    [SerializeField] Sprite[] magazine;
    [SerializeField] Sprite[] gallery;

    private SceneState state;

    public Vehicle(string name)
    {
        this.name = name;
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

    public Sprite GetTitlePic()
    {
        return titlePicture;
    }

    public void SetTitlePic(Sprite titlePic)
    {
        this.titlePicture = titlePic;
    }

    public void SetGallery(Sprite[] gallery)
    {
        this.gallery = gallery;
    }

    public Sprite[] GetGallery()
    {
        return gallery;
    }

    public void SetMagazine(Sprite[] magazine)
    {
        this.magazine = magazine;
    }

    public Sprite[] GetMagazine()
    {
        return magazine;
    }
}
