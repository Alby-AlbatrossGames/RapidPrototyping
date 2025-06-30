using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    #region Enemy Bee

    public static event Action<GameObject> OnBeeHitPlayer = null;

    public static void ReportOnBeeHitPlayer(GameObject _bee) => OnBeeHitPlayer?.Invoke(_bee);

    #endregion Enemy Bee
}
