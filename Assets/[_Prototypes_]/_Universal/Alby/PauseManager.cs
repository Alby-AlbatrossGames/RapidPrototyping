using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : GameBehaviour
{
    // Pause UI
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
    public void OnPauseButton()
    {
        TogglePause();
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0;
            //pauseMenu.transform.DOMoveX(244f, 0.3f).SetEase(Ease.OutQuint);
        }
        if (!isPaused)
        {
            Time.timeScale = gameTimeScale;
        }

        //pauseMenu.SetActive(!isPaused);
    }
}
