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

        public TMP_Text pauseBPM;

        private float beatDuration;
        private void Start()
        {
            SetBPM(12);
            StartBeat();

        }

        public void SetBPM(float value)
        {
            int newBPM = (int)value * 10;
            bpm = newBPM;
            beatDuration = 60f/bpm;
            pauseBPM.text = newBPM.ToString();

            RightVisualizer.maxValue = beatDuration;
            LeftVisualizer.maxValue = beatDuration;
        }
        void SetVisualizerValues()
        {
            RightVisualizer.value = visVal;
            LeftVisualizer.value = visVal;
        }

        private void Update()
        {
            visVal += 1 * Time.deltaTime;
            SetVisualizerValues();
        }

        private void StartBeat()
        {
            Debug.Log("Beat Start");
            EventManager.ReportOnBeatStart();

            testObj.GetComponent<Renderer>().material.color = Color.blue;

            visVal = RightVisualizer.minValue;

            ExecuteAfterSeconds((beatDuration/8) *1, EndPerfectBeatWindow);
            ExecuteAfterSeconds((beatDuration/8) *2, EndGoodBeatWindow);
            ExecuteAfterSeconds((beatDuration/8) *4, EndOKBeatWindow);
            // ExecuteAfterSeconds((beatDuration / 8) * 7, StartPerfectBeatWindow);
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
            //testObj.GetComponent<Renderer>().material.color = Color.red;
        }
        /*private void StartPerfectBeatWindow()
        {
            EventManager.ReportOnWindowStart();
            testObj.GetComponent<Renderer>().material.color = Color.blue;
        }*/
    }
}

