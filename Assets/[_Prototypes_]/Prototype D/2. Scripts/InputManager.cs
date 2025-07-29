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

        void SpawnFeedback(string _txt, Color _clr)
        {
            //GameObject fdbkTxt = Instantiate(FeedbackText, upFeedbackSpawn.transform.position, upFeedbackSpawn.transform.rotation);
            
            GameObject _a = PoolX.GetFromPool(FeedbackText, list);
            _a.GetComponent<FeedbackText>().Initialize(upFeedbackSpawn.transform.position, _txt, _clr);

        }

        #region Input Actions
        public void OnUpAction() //Addition
        {
            /*if (_EQ.correctSymbol == EquationGen.CorrectSymbol.Add)
            {*/
                switch (beatTiming)
                {
                    case BeatTiming.MISS:
                        SpawnFeedback("Miss...", Color.red);
                        break;
                    case BeatTiming.OK:
                        SpawnFeedback("OK!", Color.yellow);
                        break;
                    case BeatTiming.GOOD:
                        SpawnFeedback("Good!", Color.green);
                        break;
                    case BeatTiming.PERFECT:
                        EventManager.ReportOnInputPerfect();
                        SpawnFeedback("Perfect!", Color.blue);
                        break;
                }
            /*}*/
            
        }
        /*void OnDownAction()
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
        }*/
        #endregion Input Actions
    }
}

