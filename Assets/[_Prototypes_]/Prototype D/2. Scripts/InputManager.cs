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

        public int lives = 3;
        public int multi = 0;
        public int score = 0;

        private bool upActive = true;
        private bool downActive = true;
        private bool leftActive = true;
        private bool rightActive = true;

        private void Start()
        {
            lives = 3; multi = 0; score = 0;
        }

        void SetTimingPERFECT() => beatTiming = BeatTiming.PERFECT;
        void SetTimingGOOD() => beatTiming = BeatTiming.GOOD;
        void SetTimingOK() => beatTiming = BeatTiming.OK;
        void SetTimingMISS() => beatTiming = BeatTiming.MISS;

        private void OnEnable()
        {
            EventManager.OnBeatStart += SetTimingPERFECT;
            EventManager.OnBarComplete += ActivateInput;
            EventManager.OnPerfectWindowEnd += SetTimingGOOD;
            EventManager.OnGoodWindowEnd += SetTimingOK;
            EventManager.OnOKWindowEnd += SetTimingMISS;
        }

        void ActivateInput()
        {
            upActive = true;
            downActive = true;
            leftActive = true;
            rightActive = true;
        }
        void DeActivateInput()
        {
            upActive = false;
            downActive = false;
            leftActive = false;
            rightActive = false;
            _EQ.ShowAnswer();
        }

        void SpawnFeedback(GameObject spawn, bool missed = false)
        {
            string _txt = "ERROR";
            Color _clr = Color.white;

            if (missed)
            {
                _txt = "Incorrect";
                _clr = Color.red;
                lives -= 1;
                Debug.Log("Lives: " + lives);
            }else
            {
                switch (beatTiming)
                {
                    case BeatTiming.MISS:
                        _txt = "Miss...";
                        _clr = Color.red;
                        lives -= 1;
                        Debug.Log("Lives: " + lives);
                        break;
                    case BeatTiming.OK:
                        _txt = "OK!";
                        _clr = Color.yellow;
                        multi += 1;
                        score += 1;
                        break;
                    case BeatTiming.GOOD:
                        _txt = "Good!";
                        _clr = Color.green;
                        multi += 1;
                        score += 3;
                        break;
                    case BeatTiming.PERFECT:
                        _txt = "Perfect!";
                        _clr = Color.blue;
                        multi += 1;
                        score += 5;
                        break;
                }
            }

            
            GameObject _a = PoolX.GetFromPool(FeedbackText, list);
            _a.transform.SetParent(spawn.transform, false);
            _a.GetComponent<FeedbackText>().Initialize(spawn.transform.position, _txt, _clr);

            if (lives <= 0)
            {
                Time.timeScale = 0;
                Debug.Log("Game Over!");
                Debug.Log("Correct Answers: " + multi);
                Debug.Log("Score: " + score);
            }
        }
        void SetBtnColour(Image button)
        {
            Color defClr = button.color;
            button.color = new Color(defClr.r - 0.3f, defClr.g - 0.3f, defClr.b - 0.3f);
            ExecuteAfterSeconds(0.1f, () => button.color = defClr); //SpriteRenderer colors are 0-1, not 0-255.
        }

        #region Input Actions
        public void OnUpAction()
        {
            if (upActive)
            {
                if (_EQ.correctSymbol == EquationGen.CorrectSymbol.Add)
                {
                    SpawnFeedback(upFeedbackSpawn);
                    SetBtnColour(upButton);
                    _EQ.correctSymbol = EquationGen.CorrectSymbol.Waiting;
                }
                else
                {
                    SpawnFeedback(upFeedbackSpawn, true);
                    SetBtnColour(upButton);
                }
            }
            DeActivateInput();
        }
        void OnDownAction()
        {
            if (downActive)
            {
                if (_EQ.correctSymbol == EquationGen.CorrectSymbol.Subtract)
                {
                    SpawnFeedback(downFeedbackSpawn);
                    SetBtnColour(downButton);
                    _EQ.correctSymbol = EquationGen.CorrectSymbol.Waiting;
                }
                else
                {
                    SpawnFeedback(downFeedbackSpawn, true);
                    SetBtnColour(downButton);
                }
            }
            DeActivateInput();
        }
        void OnLeftAction()
        {
            if (leftActive)
            {
                if (_EQ.correctSymbol == EquationGen.CorrectSymbol.Multiply)
                {
                    SpawnFeedback(leftFeedbackSpawn);
                    SetBtnColour(leftButton);
                    _EQ.correctSymbol = EquationGen.CorrectSymbol.Waiting;
                }
                else
                {
                    SpawnFeedback(leftFeedbackSpawn, true);
                    SetBtnColour(leftButton);
                }
            }
            DeActivateInput();
        }
        void OnRightAction()
        {
            if (rightActive)
            {
                if (_EQ.correctSymbol == EquationGen.CorrectSymbol.Divide)
                {
                    SpawnFeedback(rightFeedbackSpawn);
                    SetBtnColour(rightButton);
                    _EQ.correctSymbol = EquationGen.CorrectSymbol.Waiting;
                }
                else
                {
                    SpawnFeedback(rightFeedbackSpawn, true);
                    SetBtnColour(rightButton);
                }
            }
            DeActivateInput();
        }
        #endregion Input Actions
    }
}

