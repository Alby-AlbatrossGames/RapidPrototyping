using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype4
{
    public class BeatManager : GameBehaviour
    {
        public float bpm;

        public float beatTimingValue;

        private float visVal;
        public Slider RightVisualizer;
        public Slider LeftVisualizer;

        public Slider BarTimerSlider;

        private float beatDuration;

        private int beatCount = 0;
        private EquationGen _EQ;

        public GameObject canvas1;
        public GameObject canvas2;

        public AudioSource audio1;
        public AudioSource audio2;
        public AudioSource audio3;


        private void Start()
        {
            //setbpm(8)
            BarTimerSlider.value = BarTimerSlider.maxValue;
            _EQ = FindFirstObjectByType<EquationGen>();
        }

        public void SetBPM(float value)
        {
            int newBPM = (int)value * 10;
            bpm = newBPM;
            beatDuration = 60f/bpm;

            RightVisualizer.maxValue = beatDuration;
            LeftVisualizer.maxValue = beatDuration;
            BarTimerSlider.maxValue = beatDuration * 4;
            BarTimerSlider.value = BarTimerSlider.maxValue;
            StartBeat();
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
            audio1.Play();

            if (beatCount < 4)
            {
                beatCount++;
            }else
            {
                EventManager.ReportOnBarComplete();
                beatCount = 1;
                BarTimerSlider.value = BarTimerSlider.maxValue;
            }

            visVal = RightVisualizer.minValue;
            canvas1.transform.localScale = Vector3.one * 1.03f; //DoScale over beatDuration
            canvas2.transform.localScale = Vector3.one * 1.03f; //DoScale over beatDuration
            canvas1.transform.DOScale(Vector3.one,beatDuration * 0.7f);
            canvas2.transform.DOScale(Vector3.one,beatDuration * 0.7f);

            ExecuteAfterSeconds((beatDuration/8) *1, EndPerfectBeatWindow);
            ExecuteAfterSeconds((beatDuration/8) *2, EndGoodBeatWindow);
            ExecuteAfterSeconds((beatDuration/8) *4, EndOKBeatWindow);
            ExecuteAfterSeconds((beatDuration/8) *5, PlayLastSound);
            ExecuteAfterSeconds(beatDuration, StartBeat);
        }
        private void EndPerfectBeatWindow()
        {
            EventManager.ReportOnPerfectWindowEnd();

        }
        private void EndGoodBeatWindow()
        {
            EventManager.ReportOnGoodWindowEnd();
            audio2.Play();
        }
        private void EndOKBeatWindow()
        {
            EventManager.ReportOnOKWindowEnd();
            audio3.Play();
        }
        private void PlayLastSound() => audio2.Play();

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

