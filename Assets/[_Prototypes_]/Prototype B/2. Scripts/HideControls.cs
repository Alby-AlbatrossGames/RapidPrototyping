using UnityEngine;

public class HideControls : MonoBehaviour
{
    private void Start() => Time.timeScale = 0;
    public void HideUI(GameObject _go) => Destroy(_go);
    public void StartGame() => Time.timeScale = 1;
}
