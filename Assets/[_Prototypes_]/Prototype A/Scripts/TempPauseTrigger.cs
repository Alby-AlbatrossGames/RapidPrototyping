using UnityEngine;

public class TempPauseTrigger : MonoBehaviour
{
    public PauseManager pm;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pm.OnPauseButton();
        }
    }
}
