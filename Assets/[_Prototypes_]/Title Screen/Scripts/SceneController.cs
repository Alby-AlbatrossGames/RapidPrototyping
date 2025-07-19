using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Quit() => Application.Quit();

    public void LoadSceneByName(string _scene) => SceneManager.LoadScene(_scene);

    public void LoadTitleScene() => LoadSceneByName("Title");
    public void ReloadActiveScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
