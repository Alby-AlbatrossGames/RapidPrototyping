using UnityEngine;

public class PauseManager : GameBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused;
    private float gameTimeScale;

    #region Start() Update()
    private void Start()
    {
        isPaused = false;
        ExecuteAfterFrames(3,() => { gameTimeScale = Time.timeScale; });
    }
    private void Update()
    {
        
    }
    #endregion Start() Update()
    public void OnPause()
    {
        TogglePause();
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused ) Time.timeScale = 0;
        if (!isPaused) Time.timeScale = gameTimeScale;
        pauseMenu.SetActive(!isPaused);
    }
}
