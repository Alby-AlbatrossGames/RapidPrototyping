using Unity.VisualScripting;
using UnityEngine;

namespace ACX
{
    public class AC
    {
        public static void ACLog(string _DebugMessage = "NoMessage", string _Origin = "null") => Debug.Log(_Origin + ": " + _DebugMessage);

    }
}

