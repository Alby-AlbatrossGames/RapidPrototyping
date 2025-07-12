using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Prototype3
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject world;
        private Vector2 wrldRotation;
        private Vector3 wrldAngle;
        [SerializeField] private int maxDist;
        [SerializeField] public bool canMove = false;

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
        void OnRotateWorld(InputValue _input)
        {
            wrldRotation = _input.Get<Vector2>();
        } // wrldRotation = _input

        void RotateWorldObject()
        {
            Debug.Log(wrldRotation);

            wrldAngle = new Vector3(wrldRotation.x * maxDist, 0, wrldRotation.y * maxDist);

            world.transform.eulerAngles = wrldAngle;
            Debug.Log(wrldAngle);
        }

    }
}

