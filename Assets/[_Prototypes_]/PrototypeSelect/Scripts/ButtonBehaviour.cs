using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class ButtonBehaviour : GameBehaviour
    {
        public BtnController btnCtrl;
        public ButtonID btnID;

        public void OnButtonEnter()
        {
            btnCtrl.OnHoverButton(btnID);
        }

        public void OnButtonExit()
        {
            btnCtrl.OnReleaseButton();
        }

        public void OnButtonActivate()
        {
            Debug.Log(btnID + " Btn Activated");
        }
    }
}

