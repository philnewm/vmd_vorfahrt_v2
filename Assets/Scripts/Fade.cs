using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private bool show;
    [SerializeField] GameObject magazinePanel;
    [SerializeField] GameObject pageSlides;

    public void FadeIt()
    {
        if (show) show = false;
        else show = true;
        magazinePanel.GetComponent<Animator>().SetBool("Show", show);
        pageSlides.SetActive(!show);
    }
}
