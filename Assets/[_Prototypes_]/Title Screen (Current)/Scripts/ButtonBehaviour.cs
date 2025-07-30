using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

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
            switch (btnID)
            {
                case ButtonID.p1:
                    LoadSceneByName("Prototype A");
                    return;
                case ButtonID.p2:
                    LoadSceneByName("Tree Game");
                    return;
                case ButtonID.p3:
                    LoadSceneByName("Pivot Game");
                    return;
                case ButtonID.p4:
                    LoadSceneByName("Math Game");
                    return;
                case ButtonID.p5:
                    //Add 5th Game
                    return;
            }

        }
        private void LoadSceneByName(string scene) => SceneManager.LoadScene(scene);
    }
}

