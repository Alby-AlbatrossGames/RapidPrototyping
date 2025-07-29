using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype4
{
    public class BeatManager : GameBehaviour
    {
        public GameObject testObj;
        public float bpm;

        public float beatTimingValue;

        private float visVal;
        public Slider RightVisualizer;
        public Slider LeftVisualizer;

        public Slider BarTimerSlider;

        public TMP_Text pauseBPM;

        private float beatDuration;

        private int beatCount = 0;
        private EquationGen _EQ;




        private void Start()
        {
            SetBPM(12);
            BarTimerSlider.value = BarTimerSlider.maxValue;
            StartBeat();
            _EQ = FindFirstObjectByType<EquationGen>();
        }

        public void SetBPM(float value)
        {
            int newBPM = (int)value * 10;
            bpm = newBPM;
            beatDuration = 60f/bpm;
            pauseBPM.text = newBPM.ToString();

            RightVisualizer.maxValue = beatDuration;
            LeftVisualizer.maxValue = beatDuration;
            BarTimerSlider.maxValue = beatDuration * 4;
        }
        void SetVisualizerValues()
        {
            RightVisualizer.value = visVal;
            LeftVisualizer.value = visVal;
        }

        private void Update()
        {
            BarTimerSlider.value -= 0.95f * Time.deltaTime;
            visVal += 1 * Time.deltaTime;
            SetVisualizerValues();
        }

        private void LoadNewEquation()
        {
            _EQ.GenerateEquation();
        }

        private void StartBeat()
        {
            EventManager.ReportOnBeatStart();

            if (beatCount < 4)
            {
                beatCount++;
            }else
            {
                EventManager.ReportOnBarComplete();
                beatCount = 1;
                BarTimerSlider.value = BarTimerSlider.maxValue;
            }

            testObj.GetComponent<Renderer>().material.color = Color.blue;

            visVal = RightVisualizer.minValue;

            ExecuteAfterSeconds((beatDuration/8) *1, EndPerfectBeatWindow);
            ExecuteAfterSeconds((beatDuration/8) *2, EndGoodBeatWindow);
            ExecuteAfterSeconds((beatDuration/8) *4, EndOKBeatWindow);
            ExecuteAfterSeconds(beatDuration, StartBeat);
        }
        private void EndPerfectBeatWindow()
        {
            EventManager.ReportOnPerfectWindowEnd();
            testObj.GetComponent<Renderer>().material.color = Color.yellow;
        }
        private void EndGoodBeatWindow()
        {
            EventManager.ReportOnGoodWindowEnd();
            testObj.GetComponent<Renderer>().material.color = Color.red;
        }
        private void EndOKBeatWindow()
        {
            EventManager.ReportOnOKWindowEnd();
            _EQ.correctSymbol = EquationGen.CorrectSymbol.Waiting;
            testObj.GetComponent<Renderer>().material.color = Color.red;
        }

        #region OnEnable/OnDisable
        private void OnEnable()
        {
            EventManager.OnBarComplete += LoadNewEquation;
        }
        private void OnDisable()
        {
            EventManager.OnBarComplete -= LoadNewEquation;
        }
        #endregion OnEnable/OnDisable
    }
}

