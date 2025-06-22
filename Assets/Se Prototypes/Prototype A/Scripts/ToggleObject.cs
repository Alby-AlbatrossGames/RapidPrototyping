using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public void ToggleObj(GameObject obj)
    {
        Debug.Log("Toggled ["+obj.name+"]");
        obj.SetActive(!obj.activeSelf);
    }
}
