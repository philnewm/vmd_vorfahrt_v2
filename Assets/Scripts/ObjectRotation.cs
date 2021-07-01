using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] GameObject engineCover;
    [SerializeField] GameObject driverDoor;
    [SerializeField] GameObject coDoor;
    private bool openCover;
    private bool openDriverDoor;
    private bool openCoDoor;

    private Animator coverAnimator;
    private Animator driverDoorAnimator;
    private Animator coDoorAnimator;

    private void Awake()
    {
        openCover = false;
        openDriverDoor = false;
        openCoDoor = false;
    }
    private void Start()
    {
        coverAnimator = engineCover.GetComponent<Animator>();
        driverDoorAnimator = driverDoor.GetComponent<Animator>();
        coDoorAnimator = coDoor.GetComponent<Animator>();
    }

    public void ToggleCover()
    {
        if (!openCover)
        {
            coverAnimator.SetBool("open", true);
            openCover = true;
        }
        else
        {
            coverAnimator.SetBool("open", false);
            openCover = false;
        }
    }


    public void ToggleDriverDoor()
    {
        if (!openDriverDoor)
        {
            driverDoorAnimator.SetBool("open", true);
            openDriverDoor = true;
        }
        else
        {
            driverDoorAnimator.SetBool("open", false);
            openDriverDoor = false;
        }
    }
    public void ToggleCoDoor()
    {
        if (!openCoDoor)
        {
            coDoorAnimator.SetBool("open", true);
            openCoDoor = true;
        }
        else
        {
            coDoorAnimator.SetBool("open", false);
            openCoDoor = false;
        }
    }
}
