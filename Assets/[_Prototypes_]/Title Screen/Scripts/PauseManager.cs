using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseManager : GameBehaviour
{
    // Pause UI
    public GameObject pauseMenu;
    public bool isPaused;
    private float gameTimeScale;

    public UnityEvent selectInitialButton;

    public Image pauseBG;

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

        if (isPaused)
        {
            pauseMenu.SetActive(isPaused);
            selectInitialButton.Invoke();
            Time.timeScale = 0;
            pauseBG.DOFade(100f, 0.3f);
            return;
        }
        if (!isPaused)
        {
            Time.timeScale = gameTimeScale;
            pauseBG.DOFade(0, 0.3f).OnComplete(() => pauseMenu.SetActive(isPaused));
            return;
        }
    }

    public void Resume() => OnPauseButton();
    public void LoadSceneByName(string scene) => SceneManager.LoadScene(scene);
    public void ReloadActiveScene() => LoadSceneByName(SceneManager.GetActiveScene().name);
    public void QuitApp() => Application.Quit();
}
