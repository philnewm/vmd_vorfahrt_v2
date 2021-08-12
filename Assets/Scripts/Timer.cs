using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] VehicleScene vehicleScene;
    [SerializeField] GameObject timerField;
    private float displayTimeValue;

    private void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (displayTimeValue > vehicleScene.GetStateVisibleCountdown() + 1)
        {
            displayTimeValue -= Time.deltaTime;
            timerField.transform.SetAsFirstSibling();
            timerField.SetActive(false);
        }
        else if (displayTimeValue > 0)
        {
            displayTimeValue -= Time.deltaTime;
            DisplayTime();
        }
        else
        {
            displayTimeValue = 0;
            sceneLoader.LoadMenuScene();
        }
    }

    private void DisplayTime()
    {
        timerField.transform.SetAsLastSibling();
        timerField.SetActive(true);
        float seconds = Mathf.FloorToInt(displayTimeValue);
        timerField.GetComponentInChildren<TextMeshProUGUI>().text = seconds.ToString();
    }

    public void ResetTimer()
    {
        displayTimeValue = vehicleScene.GetStateInvisibleCountdown() + vehicleScene.GetStateVisibleCountdown();
    }
}
