using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype4
{
    public class GameStart : MonoBehaviour
    {
        public Slider slider;
        private BeatManager _BM;
        public TMP_Text bpmTXT;
        private void Start()
        {
            Time.timeScale = 0;
            _BM = FindFirstObjectByType<BeatManager>();
        }

        public void StartGame()
        {
            Time.timeScale = 1;
            Destroy(gameObject);
            _BM.SetBPM(slider.value);
        }

        public void SliderText(float val)
        {
            bpmTXT.text = (val * 10).ToString();
        }
    }
}