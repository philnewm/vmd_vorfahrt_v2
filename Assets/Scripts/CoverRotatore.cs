using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverRotatore : MonoBehaviour
{
    [SerializeField] GameObject engineCover;
    [SerializeField] float openingAngle;
    private bool open;
    private Quaternion defaultYAngle;
    private Quaternion angle;
    private bool buttonPressed;

    private void Awake()
    {
        defaultYAngle = engineCover.transform.localRotation;
        open = false;
    }
    private void Start()
    {
        angle = Quaternion.Euler(openingAngle, 0, 0);
    }

    private void Update()
    {
        engineCover.transform.localRotation = Quaternion.Lerp(angle, defaultYAngle, Time.deltaTime);
    }

    public void ToggleCover()
    {
        buttonPressed = true;
        open = true;
    }
}
