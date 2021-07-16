using UnityEngine;

public class DisableObject : MonoBehaviour
{
    [SerializeField] VehicleScene sceneCtl;
    public void Disable()
    {
        if (!sceneCtl.GetShowText())
        {
            gameObject.transform.SetAsFirstSibling();
            gameObject.SetActive(false);
        }
    }
}
