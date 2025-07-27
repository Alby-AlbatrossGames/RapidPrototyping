using UnityEngine;

namespace Prototype4
{
    public class ToggleHide : MonoBehaviour
    {
        public void ToggleElement(GameObject go) => go.SetActive(!go.activeSelf);
    }
}

