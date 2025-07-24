using Unity.VisualScripting;
using UnityEngine;

namespace Prototype4
{
    public class BeatManager : GameBehaviour
    {
        public GameObject testObj;
        public int bpm = 120;
        private float beatDuration;
        private void Start()
        {
            beatDuration = 60f / bpm;
            StartBeat();
        }

        private void StartBeat()
        {
            Debug.Log("[MISS END]");
            EventManager.ReportOnBeatStart();

            ExecuteAfterSeconds(beatDuration/4, EndPerfectBeatWindow);
            ExecuteAfterSeconds((beatDuration/4)*2, EndGoodBeatWindow);
            ExecuteAfterSeconds((beatDuration/4)*3, EndOKBeatWindow);
            ExecuteAfterSeconds(beatDuration, StartBeat);
        }
        private void EndPerfectBeatWindow()
        {
            Debug.Log("[PERFECT END]");
            EventManager.ReportOnPerfectWindowEnd();
        }
        private void EndGoodBeatWindow()
        {
            Debug.Log("[GOOD END]");
            EventManager.ReportOnGoodWindowEnd();
        }
        private void EndOKBeatWindow()
        {
            Debug.Log("[OK END]");
            EventManager.ReportOnOKWindowEnd();
        }
    }
}

