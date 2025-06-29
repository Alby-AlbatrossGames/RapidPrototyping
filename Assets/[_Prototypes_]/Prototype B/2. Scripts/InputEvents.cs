using System;
using UnityEngine;

public class InputEvents
{
    #region Movement Events
    public static event Action OnInputUp = null;
    public static event Action OnInputDown = null;
    public static event Action OnInputLeft = null;
    public static event Action OnInputRight = null;

    public static void ReportOnInputUp() => OnInputUp?.Invoke();
    public static void ReportOnInputDown() => OnInputDown?.Invoke();
    public static void ReportOnInputLeft() => OnInputLeft?.Invoke();
    public static void ReportOnInputRight() => OnInputRight?.Invoke();
    #endregion Movement Events

    #region Action Events
    public static event Action OnInputAction1 = null;
    public static event Action OnInputAction2 = null;
    public static event Action OnInputAction3 = null;
    public static event Action OnInputAction4 = null;

    public static void ReportOnInputAction1() => OnInputAction1?.Invoke();
    public static void ReportOnInputAction2() => OnInputAction2?.Invoke();
    public static void ReportOnInputAction3() => OnInputAction3?.Invoke();
    public static void ReportOnInputAction4() => OnInputAction4?.Invoke();
    #endregion Action Events

}
