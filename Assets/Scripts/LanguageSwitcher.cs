using UnityEngine;
using UnityEngine.UI;

public class LanguageSwitcher : MonoBehaviour
{
    [SerializeField] Button gerButton;
    [SerializeField] Button engButton;
    SceneState state;

    private void Awake()
    {
        state = FindObjectOfType<SceneState>();
    }

    private void Start()
    {
        ChangeFlag();
    }

    public void SwitchLanguage()
    {
        SetLanguage();
        ChangeFlag();
    }

    private void SetLanguage()
    {
        if (state.GetLanguage() == "ger")
        {
            state.SetLanguage("eng");
        }
        else
        {
            state.SetLanguage("ger");
        }
    }

    private void ChangeFlag()
    {
        if (state.GetLanguage() == "eng")
        {
            gerButton.GetComponent<Image>().color = Color.grey;
            engButton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            gerButton.GetComponent<Image>().color = Color.white;
            engButton.GetComponent<Image>().color = Color.grey;
        }
    }
}
