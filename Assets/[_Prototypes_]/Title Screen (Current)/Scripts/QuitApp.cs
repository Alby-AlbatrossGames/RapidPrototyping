using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitApp : MonoBehaviour
{
    public void QuitApplication() => Application.Quit();
    public void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
