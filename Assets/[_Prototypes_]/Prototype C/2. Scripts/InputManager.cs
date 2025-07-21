using ACX;
using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Prototype3
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject world;
        private Vector2 joystickInput;
        private Vector3 wrldAngle;
        [SerializeField] private int maxDist;
        [SerializeField] public bool canMove = false;
        [Header("UI")]
        [SerializeField] public TMP_Text gamepadControlUIOne;
        [SerializeField] public TMP_Text gamepadControlUITwo;
        [SerializeField] public TMP_Text keyboardControlUIOne;
        [SerializeField] public TMP_Text keyboardControlUITwo;
        public GameObject controlsCanvas;

        private PauseManager pauseManager;

        #region Start() and Update()
        private void Start() 
        { 
            Time.timeScale = 2f;
            StartCoroutine(InitTimer());
            pauseManager = FindFirstObjectByType<PauseManager>();
        }

        IEnumerator InitTimer()
        {
            yield return new WaitForSeconds(5); //Time for intro to finish = 4.5s
            canMove = true;
        }
        private void Update()
        {
            if (canMove)
                RotateWorldObject();
        }
        #endregion Start() and Update()

        #region InputAction Events
        void OnRotateWorld(InputValue _input)
        {
            joystickInput = _input.Get<Vector2>();          
            if (PlayerInput.GetPlayerByIndex(0).currentControlScheme == "Gamepad")
                ShowGamepadControls();

            else if (PlayerInput.GetPlayerByIndex(0).currentControlScheme == "Keyboard&Mouse")
                ShowKeyboardControls();
        }
        public void OnPause()
        {
            pauseManager.OnPauseButton();
            controlsCanvas.SetActive(!pauseManager.isPaused);
        }

        #endregion InputAction Events

        void RotateWorldObject() //does all the heavy lifting
        {
            wrldAngle = new Vector3(joystickInput.x * maxDist, 0, joystickInput.y * maxDist);
            world.transform.eulerAngles = wrldAngle;
        }

        void ShowGamepadControls()
        {
            gamepadControlUIOne.color = Color.white;
            gamepadControlUITwo.color = Color.white;
            keyboardControlUIOne.color = Color.gray;
            keyboardControlUITwo.color = Color.gray;
        }

        void ShowKeyboardControls()
        {
            gamepadControlUIOne.color = Color.gray;
            gamepadControlUITwo.color = Color.gray;
            keyboardControlUIOne.color = Color.white;
            keyboardControlUITwo.color = Color.white;
        }

    }
}

