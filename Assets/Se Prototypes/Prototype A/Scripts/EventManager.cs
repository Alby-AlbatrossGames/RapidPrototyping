using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 
namespace BV
{
    public class EventManager : GameBehaviour
    {
        public UnityEvent OnFreezeAbility = null;

        private void Start()
        {
            
        }
        private void Update()
        {
            
        }

        public void TriggerFreezeAbility()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
                OnFreezeAbility?.Invoke();
        }

    }
}