using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PauseManager : GameBehaviour
{
    // Pause UI
    public GameObject pauseMenu;
    public bool isPaused;
    private float gameTimeScale;

    public UnityEvent selectInitialButton;

    #region Start() Update()
    private void Start()
    {
        isPaused = false;
        ExecuteAfterFrames(3,() => { 
            if (Time.timeScale != 0) 
                gameTimeScale = Time.timeScale;
            else gameTimeScale = 1;
        });
    }
    private void Update()
    {
        
    }
    #endregion Start() Update()
    public void OnPauseButton()
    {
        TogglePause();
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        Debug.Log("Paused = "+isPaused);
        pauseMenu.SetActive(isPaused);

        if (isPaused)
        {
            selectInitialButton.Invoke();
            Time.timeScale = 0;
        }
        if (!isPaused)
        {
            Time.timeScale = gameTimeScale;
        }
    }

    public void Resume() => OnPauseButton();
    public void LoadSceneByName(string scene) => SceneManager.LoadScene(scene);
    public void ReloadActiveScene() => LoadSceneByName(SceneManager.GetActiveScene().name);
    public void QuitApp() => Application.Quit();
}
