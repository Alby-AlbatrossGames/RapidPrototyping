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
        [Header("Pause UI Script")]
        public UIBounceUpDown _PauseUI;
        [Header("UI")]
        [SerializeField] public TMP_Text gamepadControlUIOne;
        [SerializeField] public TMP_Text gamepadControlUITwo;
        [SerializeField] public TMP_Text keyboardControlUIOne;
        [SerializeField] public TMP_Text keyboardControlUITwo;
        public GameObject controlsCanvas;

        #region Start() and Update()
        private void Start() 
        { 
            Time.timeScale = 2f;
            StartCoroutine(InitTimer());
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
            Debug.Log("joystickInput: " + joystickInput);
        }
        public void OnPause()
        {
            _PauseUI.PauseGame();
            controlsCanvas.SetActive(!_PauseUI.paused);
        }

        #endregion InputAction Events

        void RotateWorldObject() //does all the heavy lifting
        {
            wrldAngle = new Vector3(joystickInput.x * maxDist, 0, joystickInput.y * maxDist);
            world.transform.eulerAngles = wrldAngle;
            Debug.Log("wrldAngle: "+wrldAngle);
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

