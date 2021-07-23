using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    private bool openCover;
    private bool openDriverDoor;
    private bool openCoDoor;
    private GameObject driverDoor;
    private GameObject coDriverDoor;
    private GameObject engineCover;
    private Animator coverAnimator;
    private Animator driverDoorAnimator;
    private Animator coDoorAnimator;
    [SerializeField] VehicleScene vehicleCtl;

    private void Awake()
    {
        openCover = false;
        openDriverDoor = false;
        openCoDoor = false;
    }
    private void Start()
    {
        if (vehicleCtl.CheckVehicle() == 3 && vehicleCtl.CheckSide() == 0) //needs cleanup
        {
            engineCover = GameObject.Find("paenomen_engine_cover");
            driverDoor = GameObject.Find("paenomen_driver_door");
            coDriverDoor = GameObject.Find("paenomen_co_driver_door");

            coverAnimator = engineCover.GetComponent<Animator>();
            driverDoorAnimator = driverDoor.GetComponent<Animator>();
            coDoorAnimator = coDriverDoor.GetComponent<Animator>();
        }
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
