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
    [SerializeField] Mesh vehicleModell;
    [SerializeField] Material opaqueMat;
    [SerializeField] Material transpMat;

    string language;

    public Vehicle(string name, string language)
    {
        this.language = language;
        this.name = name;
    }

    public void ChangeLanguage(string language)
    {
        this.language = language;
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

    public string GetHeader()
    {
        if (language == "ger")
        {
            return gerHeader;
        }
        else
        {
            return engHeader;
        }
    }

    public string GetPreDescr()
    {
        if (language == "ger")
        {
            return gerPreDescr;
        }
        else
        {
            return engPreDescr;
        }
    }

    public string Getdescr()
    {
        if (language == "ger")
        {
            return gerDescr;
        }
        else
        {
            return engDescr;
        }
    }

    public Sprite GetTitlePic()
    {
        return titlePicture;
    }

    public void SetTitlePic(Sprite titlePic)
    {
        this.titlePicture = titlePic;
    }
}
