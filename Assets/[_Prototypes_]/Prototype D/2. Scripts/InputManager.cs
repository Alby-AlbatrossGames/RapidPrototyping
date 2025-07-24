using TMPro;
using UnityEngine;

namespace Prototype4
{
    
    
    public class InputManager : MonoBehaviour
    {
        public enum BeatTiming { MISS, PERFECT, GOOD, OK }
        public BeatTiming beatTiming = BeatTiming.MISS;

        public TMP_Text upFeedback;
        public TMP_Text downFeedback;
        public TMP_Text leftFeedback;
        public TMP_Text rightFeedback;

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
                    upFeedback.text = "Miss...";
                    upFeedback.color = Color.red;
                    break;
                case BeatTiming.OK:
                    upFeedback.text = "OK";
                    upFeedback.color = Color.yellow;
                    break;
                case BeatTiming.GOOD:
                    upFeedback.text = "Good!";
                    upFeedback.color = Color.green;
                    break;
                case BeatTiming.PERFECT:
                    upFeedback.text = "Perfect!";
                    upFeedback.color = Color.blue;
                    break;
                default:
                    upFeedback.text = "ERROR";
                    upFeedback.color = Color.black;
                    break;
            }
        }
        void OnDownAction()
        {
            switch (beatTiming)
            {
                case BeatTiming.MISS:
                    downFeedback.text = "Miss...";
                    downFeedback.color = Color.red;
                    break;
                case BeatTiming.OK:
                    downFeedback.text = "OK!";
                    downFeedback.color = Color.yellow;
                    break;
                case BeatTiming.GOOD:
                    downFeedback.text = "Good!";
                    downFeedback.color = Color.green;
                    break;
                case BeatTiming.PERFECT:
                    downFeedback.text = "Perfect!";
                    downFeedback.color = Color.blue;
                    break;
                default:
                    downFeedback.text = "ERROR";
                    downFeedback.color = Color.black;
                    break;
            }
        }
        void OnLeftAction()
        {
            switch (beatTiming)
            {
                case BeatTiming.MISS:
                    leftFeedback.text = "Miss...";
                    leftFeedback.color = Color.red;
                    break;
                case BeatTiming.OK:
                    leftFeedback.text = "OK!";
                    leftFeedback.color = Color.yellow;
                    break;
                case BeatTiming.GOOD:
                    leftFeedback.text = "Good!";
                    leftFeedback.color = Color.green;
                    break;
                case BeatTiming.PERFECT:
                    leftFeedback.text = "Perfect!";
                    leftFeedback.color = Color.blue;
                    break;
                default:
                    leftFeedback.text = "ERROR";
                    leftFeedback.color = Color.black;
                    break;
            }
        }
        void OnRightAction()
        {
            switch (beatTiming)
            {
                case BeatTiming.MISS:
                    rightFeedback.text = "Miss...";
                    rightFeedback.color = Color.red;
                    break;
                case BeatTiming.OK:
                    rightFeedback.text = "OK!";
                    rightFeedback.color = Color.yellow;
                    break;
                case BeatTiming.GOOD:
                    rightFeedback.text = "Good!";
                    rightFeedback.color = Color.green;
                    break;
                case BeatTiming.PERFECT:
                    rightFeedback.text = "Perfect!";
                    rightFeedback.color = Color.blue;
                    break;
                default:
                    rightFeedback.text = "ERROR";
                    rightFeedback.color = Color.black;
                    break;
            }
        }
        #endregion Input Actions
    }
}

