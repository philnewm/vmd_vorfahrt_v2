using UnityEngine;
using System.Collections;

[System.Serializable]
public class Vehicle
{
    [SerializeField] string name;
    [SerializeField] string title;
    [SerializeField] string year;
    [SerializeField] string header;
    [TextArea(10,5)] [SerializeField] string preDescr;
    [TextArea(10,5)] [SerializeField] string descr;

    [SerializeField] Texture2D titlePicture;

    [SerializeField] Mesh vehicleModell;
    [SerializeField] Material opaqueMat;
    [SerializeField] Material transpMat;

    [SerializeField] Mesh baseModell;
    [SerializeField] Material baseMat;

    public Vehicle(string name) //, string year, string header, string preDescr, string descr)
    {
        this.name = name;
        //this.year = year;
        //this.header = header;
        //this.preDescr = preDescr;
        //this.descr = descr;
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
        return header;
    }

    public string GetPreDescr()
    {
        return preDescr;
    }

    public string Getdescr()
    {
        return preDescr;
    }

    public Texture2D GetTitlePic()
    {
        return titlePicture;
    }
}
