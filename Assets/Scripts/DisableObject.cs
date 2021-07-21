using UnityEngine;

public class DisableObject : MonoBehaviour
{
    [SerializeField] VehicleScene sceneCtl;
    public void DisableText()
    {
        if (!sceneCtl.GetShowText())
        {
            gameObject.transform.SetAsFirstSibling();
            gameObject.SetActive(false);
        }
    }


    public void Disable3D()
    {
        if (!sceneCtl.GetShow3D())
        {
            gameObject.transform.SetAsFirstSibling();
            gameObject.SetActive(false);
        }
    }
}
