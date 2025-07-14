using DG.Tweening;
using Prototype3;
using UnityEngine;

namespace ACX
{
    public class UIBounceUpDown : MonoBehaviour
    {
        public bool paused = false;

        public void PauseGame()
        {
            paused =! paused;

            if (paused)
                BounceIn();
            else BounceOut();
        }
        void BounceIn()
        {
            Time.timeScale = 0;
            transform.DOMoveY(Screen.height/2, 1.5f).SetEase(Ease.OutBounce).SetUpdate(true);
        }

        void BounceOut()
        {
            Time.timeScale = 1;
            transform.DOMoveY(-Screen.height/2, 1.5f).SetEase(Ease.OutExpo).SetUpdate(true);
        }
    }
}
