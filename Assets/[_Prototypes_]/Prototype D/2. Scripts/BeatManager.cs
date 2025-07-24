using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype4
{
    public class BeatManager : GameBehaviour
    {
        public GameObject testObj;
        public int bpm = 120;

        public float beatTimingValue;

        private float sliderVal;
        public Slider RightSlider;
        public Slider LeftSlider;

        private float beatDuration;
        private void Start()
        {
            beatDuration = 60f / bpm;
            StartBeat();
            RightSlider.maxValue = beatDuration;
            LeftSlider.maxValue = beatDuration;

        }
        void SetSliderValues()
        {
            RightSlider.value = sliderVal;
            LeftSlider.value = sliderVal;
        }

        private void Update()
        {
            sliderVal += 1 * Time.deltaTime;
            SetSliderValues();
        }

        private void StartBeat()
        {
            Debug.Log("Beat Start");
            EventManager.ReportOnBeatStart();

            sliderVal = RightSlider.minValue;

            ExecuteAfterSeconds((beatDuration/8) *1, EndPerfectBeatWindow);
            ExecuteAfterSeconds((beatDuration/8) *3, EndGoodBeatWindow);
            ExecuteAfterSeconds((beatDuration/8) *6, EndOKBeatWindow);
            // ExecuteAfterSeconds((beatDuration / 8) * 7, StartPerfectBeatWindow);
            ExecuteAfterSeconds(beatDuration, StartBeat);
        }
        private void EndPerfectBeatWindow()
        {
            EventManager.ReportOnPerfectWindowEnd();
            testObj.GetComponent<Renderer>().material.color = Color.green;
        }
        private void EndGoodBeatWindow()
        {
            EventManager.ReportOnGoodWindowEnd();
            testObj.GetComponent<Renderer>().material.color = Color.yellow;
        }
        private void EndOKBeatWindow()
        {
            EventManager.ReportOnOKWindowEnd();
            testObj.GetComponent<Renderer>().material.color = Color.red;
        }
        /*private void StartPerfectBeatWindow()
        {
            EventManager.ReportOnWindowStart();
            testObj.GetComponent<Renderer>().material.color = Color.blue;
        }*/
    }
}

