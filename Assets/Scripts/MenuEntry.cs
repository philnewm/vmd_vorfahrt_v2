using UnityEngine;
using TMPro;

public class MenuEntry : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI vehicleName;
    [SerializeField] TextMeshProUGUI year;

    public void SetYear(string importedYear)
    {
        year.text = importedYear;
    }

    public void Setname(string importedName)
    {
        vehicleName.text = importedName;
    }

}
