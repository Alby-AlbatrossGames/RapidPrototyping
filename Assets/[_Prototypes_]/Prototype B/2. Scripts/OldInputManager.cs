using UnityEngine;

namespace _Universal.InputSystem
{
    public class OldInputManager : GameBehaviour
    {
        private void Update()
        {
            PlayerMovement();
            PlayerActions();
        }

        void PlayerMovement()
        {
            if (Input.GetKey(KeyCode.W)) //up
                InputEvents.ReportOnInputUp();
            if (Input.GetKey(KeyCode.S)) //down
                InputEvents.ReportOnInputDown();

            if (Input.GetKey(KeyCode.A)) //left
                InputEvents.ReportOnInputLeft();
            if (Input.GetKey(KeyCode.D)) //right
                InputEvents.ReportOnInputRight();
        }
        void PlayerActions()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                InputEvents.ReportOnInputAction1(); //Action 1
            if ((Input.GetKeyDown(KeyCode.LeftShift)) || (Input.GetKeyDown(KeyCode.RightShift)))
                InputEvents.ReportOnInputAction2(); //Action 2
            if (Input.GetKeyDown(KeyCode.Mouse0))
                InputEvents.ReportOnInputAction3(); //Action 3
            if (Input.GetKeyDown(KeyCode.Mouse1))
                InputEvents.ReportOnInputAction4(); //Action 4
        }
    }
}

