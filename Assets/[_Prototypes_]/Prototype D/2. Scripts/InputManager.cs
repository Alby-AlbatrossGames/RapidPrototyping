using UnityEngine;

namespace Prototype4
{
    
    
    public class InputManager : MonoBehaviour
    {
        public enum BeatTiming { MISS, PERFECT, GOOD, OK }
        public BeatTiming beatTiming = BeatTiming.MISS;

        private void Update()
        {
            
        }

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
                    Debug.Log("Missed!");
                    break;
                case BeatTiming.OK:
                    Debug.Log("OK!");
                    break;
                case BeatTiming.GOOD:
                    Debug.Log("Good!");
                    break;
                case BeatTiming.PERFECT:
                    Debug.Log("Perfect!");
                    break;
                default:
                    Debug.Log("Error");
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

