using TMPro;
using UnityEngine;
using System.Collections.Generic;

namespace Prototype4
{
    
    
    public class InputManager : MonoBehaviour
    {
        public enum BeatTiming { MISS, PERFECT, GOOD, OK }
        public BeatTiming beatTiming = BeatTiming.MISS;

        public GameObject upFeedbackSpawn;
        public GameObject downFeedbackSpawn;
        public GameObject leftFeedbackSpawn;
        public GameObject rightFeedbackSpawn;

        public EquationGen _EQ;
        public GameObject FeedbackText;
        public List<GameObject> list;

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

        void SpawnFeedback(GameObject spawn)
        {
            string _txt = "ERROR";
            Color _clr = Color.white;
            switch (beatTiming)
            {
                case BeatTiming.MISS:
                    _txt = "Miss...";
                    _clr = Color.red;
                    break;
                case BeatTiming.OK:
                    _txt = "OK!";
                    _clr = Color.yellow;
                    break;
                case BeatTiming.GOOD:
                    _txt = "Good!";
                    _clr = Color.green;
                    break;
                case BeatTiming.PERFECT:
                    _txt = "Perfect!";
                    _clr = Color.blue;
                    break;
            }
            GameObject _a = PoolX.GetFromPool(FeedbackText, list);
            _a.transform.SetParent(spawn.transform, false);
            _a.GetComponent<FeedbackText>().Initialize(spawn.transform.position, _txt, _clr);
        }

        #region Input Actions
        public void OnUpAction() //Addition
        {
            /*if (_EQ.correctSymbol == EquationGen.CorrectSymbol.Add)
            {*/
            SpawnFeedback(upFeedbackSpawn);
            /*}*/
            
        }
        void OnDownAction()
        {
            SpawnFeedback(downFeedbackSpawn);
        }
        void OnLeftAction()
        {
            SpawnFeedback(leftFeedbackSpawn);
        }
        void OnRightAction()
        {
            SpawnFeedback(rightFeedbackSpawn);
        }
        #endregion Input Actions
    }
}

