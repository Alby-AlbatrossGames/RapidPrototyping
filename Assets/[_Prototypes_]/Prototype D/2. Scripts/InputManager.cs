using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Prototype4
{
    
    
    public class InputManager : GameBehaviour
    {
        public enum BeatTiming { MISS, PERFECT, GOOD, OK }
        public BeatTiming beatTiming = BeatTiming.MISS;

        public GameObject upFeedbackSpawn;
        public Image upButton;
        public GameObject downFeedbackSpawn;
        public Image downButton;
        public GameObject leftFeedbackSpawn;
        public Image leftButton;
        public GameObject rightFeedbackSpawn;
        public Image rightButton;

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
        void SetBtnColour(Image button)
        {
            Color defClr = button.color;
            button.color = new Color(defClr.r - 0.3f, defClr.g - 0.3f, defClr.b - 0.3f);
            ExecuteAfterSeconds(0.1f, () => button.color = defClr); //SpriteRenderer colors are 0-1, not 0-255.
        }

        #region Input Actions
        public void OnUpAction() //Addition
        {
            /*if (_EQ.correctSymbol == EquationGen.CorrectSymbol.Add)
            {*/
            SpawnFeedback(upFeedbackSpawn);
            SetBtnColour(upButton);
            /*}*/
            
        }
        void OnDownAction()
        {
            SpawnFeedback(downFeedbackSpawn);
            SetBtnColour(downButton);
        }
        void OnLeftAction()
        {
            SpawnFeedback(leftFeedbackSpawn);
            SetBtnColour(leftButton);
        }
        void OnRightAction()
        {
            SpawnFeedback(rightFeedbackSpawn);
            SetBtnColour(rightButton);
        }
        #endregion Input Actions
    }
}

