using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.UI;

namespace MainMenu
{
    public enum ButtonID { p1, p2, p3, p4, p5 }
    public class BtnController : MonoBehaviour
    {
        public List<GameObject> buttons;

        private float defaultWidth = 180f   ;
        private float minWidth     = 90f ;
        private float maxWidth     = 540f   ;

        public void OnHoverButton(ButtonID _btn)
        {
            switch (_btn)
            {
                case ButtonID.p1:
                    Debug.Log("case 1");
                    GrowButton(0);
                break;

                case ButtonID.p2:
                    GrowButton(1);
                    break;

                case ButtonID.p3:
                    GrowButton(2);
                    break;

                case ButtonID.p4:
                    GrowButton(3);
                    break;

                case ButtonID.p5:
                    GrowButton(4);
                    break;
            }
        }

        public void OnReleaseButton()
        {
            ResetAllButtons();
        }

        public void ResetAllButtons()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                //DOTween.Kill(buttons[i]);
                buttons[i].GetComponent<RectTransform>().DOSizeDelta(new Vector2(defaultWidth, 280), 0.5f).SetUpdate(true);
            }
        }

        private void GrowButton(int _id)
        {
            //DOTween.Kill(buttons[_id]);
            buttons[_id].GetComponent<RectTransform>().DOSizeDelta(new Vector2(maxWidth, 280), 0.5f).SetUpdate(true);

            for (int i = 0; i < buttons.Count; i++)
            {
                if (i != _id) buttons[i].GetComponent<RectTransform>().DOSizeDelta(new Vector2(minWidth, 280), 0.5f).SetUpdate(true);
            }
        }

        private void ShrinkButton(RectTransform _btn)
        {
            DOTween.Kill(_btn);
            _btn.DOSizeDelta(new Vector2(minWidth, 280), 0.5f);
        }

        private void ResetButton(RectTransform _btn)
        {
            DOTween.Kill(_btn);
            _btn.DOSizeDelta(new Vector2(defaultWidth, 280), 0.5f);
        }
    }
}

