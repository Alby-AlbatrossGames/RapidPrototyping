using UnityEngine;

public class ToggleHide : MonoBehaviour
{
    public GameObject toggleHide;
    private void Update()
    {
        ClassicInputTrigger();
    }

    private void ClassicInputTrigger()
    {
        if (Input.GetKeyDown(KeyCode.H))
            HideObject(toggleHide);
    }

    public void HideObject(GameObject _go)
    {
        Debug.Log("Hiding: ["+toggleHide.name+"]");
        toggleHide.SetActive(!toggleHide.activeSelf);
    }
}
