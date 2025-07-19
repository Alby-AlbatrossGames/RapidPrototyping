using UnityEngine;

public class MenuPauseTranslator : MonoBehaviour
{
    private PauseManager pauseManager;

    private void Start()
    {
        pauseManager = GetComponentInChildren<PauseManager>();
    }

    private void OnPause()
    {
        pauseManager.OnPauseButton();
        Debug.Log("Pause Button Pressed");
    }
}
