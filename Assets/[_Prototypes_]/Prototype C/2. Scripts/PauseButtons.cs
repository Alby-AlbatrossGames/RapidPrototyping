using ACX;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype3
{
    public class PauseButtons : MonoBehaviour
    {
        public InputManager _inputManager;
        public void OnClickResume()
        {
            _inputManager.OnPause();
        }
        public void OnClickRestart()
        {
            LoadScene(SceneManager.GetActiveScene().name);
        }
        public void OnClickReturnToMenu()
        {
            LoadScene("Title");
        }
        public void OnClickExitApp()
        {
            Application.Quit();
        }

        private void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);
    }
}

