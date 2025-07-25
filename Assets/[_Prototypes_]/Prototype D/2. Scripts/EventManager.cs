using System;
using UnityEngine;

namespace Prototype4
{
    public class EventManager : MonoBehaviour
    {

        public static event Action OnBeatStart = null;
        public static event Action OnWindowStart = null;
        public static event Action OnPerfectWindowEnd = null;
        public static event Action OnGoodWindowEnd = null;
        public static event Action OnOKWindowEnd = null;

        public static void ReportOnBeatStart() => OnBeatStart?.Invoke();
        public static void ReportOnWindowStart() => OnWindowStart?.Invoke();
        public static void ReportOnPerfectWindowEnd() => OnPerfectWindowEnd?.Invoke();
        public static void ReportOnGoodWindowEnd() => OnGoodWindowEnd?.Invoke();
        public static void ReportOnOKWindowEnd() => OnOKWindowEnd?.Invoke();

    }
}

