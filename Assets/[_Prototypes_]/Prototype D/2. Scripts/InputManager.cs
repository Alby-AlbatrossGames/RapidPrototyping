using UnityEngine;

namespace Prototype4
{
    public class InputManager : MonoBehaviour
    {
        public void TestIt()
        {
            Debug.Log("UP");
        }
        void OnDownAction()
        {
            Debug.Log("DOWN");
        }
        void OnLeftAction()
        {
            Debug.Log("LEFT");
        }
        void OnRightAction()
        {
            Debug.Log("RIGHT");
        }
    }
}

