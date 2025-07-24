using TMPro;
using UnityEngine;

namespace Prototype4
{
    
    
    public class InputManager : MonoBehaviour
    {
        public enum BeatTiming { MISS, PERFECT, GOOD, OK }
        public BeatTiming beatTiming = BeatTiming.MISS;

        public TMP_Text testText;

        void SetTimingPERFECT() => beatTiming = BeatTiming.PERFECT;
        void SetTimingGOOD() => beatTiming = BeatTiming.GOOD;
        void SetTimingOK() => beatTiming = BeatTiming.OK;
        void SetTimingMISS() => beatTiming = BeatTiming.MISS;

        private void OnEnable()
        {
            EventManager.OnBeatStart += SetTimingPERFECT;
            EventManager.OnPerfectWindowEnd += SetTimingGOOD;
            EventManager.OnGoodWindowEnd += SetTimingOK;
            EventManager.OnOKWindowEnd += SetTimingMISS;
        }

        #region Input Actions
        public void OnUpAction()
        {
            switch (beatTiming)
            {
                case BeatTiming.MISS:
                    testText.text = "Miss...";
                    testText.color = Color.red;
                    break;
                case BeatTiming.OK:
                    testText.text = "OK!";
                    testText.color = Color.yellow;
                    break;
                case BeatTiming.GOOD:
                    testText.text = "Good!";
                    testText.color = Color.green;
                    break;
                case BeatTiming.PERFECT:
                    testText.text = "Perfect!";
                    testText.color = Color.blue;
                    break;
                default:
                    testText.text = "ERROR";
                    testText.color = Color.black;
                    break;


            }
        }
        void OnDownAction()
        {
            Debug.Log("DOWN");
        }
        void OnLeftAction()
        {
            Debug.Log("LEFT");
        }
        void OnRightAction()
        {
            Debug.Log("RIGHT");
        }
        #endregion Input Actions
    }
}

