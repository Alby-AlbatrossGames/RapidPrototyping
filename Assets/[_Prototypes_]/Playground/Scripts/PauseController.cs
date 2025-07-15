using UnityEngine;
using UnityEngine.Android;

public class PauseController : MonoBehaviour
{
    bool paused;
    public GameObject pausePanel;
    private void Start()
    {
        paused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    public void Pause()
    {
        paused = !paused;
        if (paused)
            Time.timeScale = 0;
        if (!paused)
            Time.timeScale = 1;
    }
}
