using UnityEngine;
using UnityEngine.Events;

namespace MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        public UnityEvent focusTarget;

        private void Start()
        {
            focusTarget.Invoke();
        }
    }
}

