using UnityEngine;

public class PatchNotes : MonoBehaviour
{
    public GameObject toggleHide;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            toggleHide.SetActive(!toggleHide.activeSelf);
    }
}
