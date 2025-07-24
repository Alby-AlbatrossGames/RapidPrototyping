using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;

namespace MainMenu
{
    public enum ButtonID { p1, p2, p3, p4, p5 }
    public class BtnController : MonoBehaviour
    {
        public TMP_Text title;
        public List<GameObject> buttons;
        public List<GameObject> previews;

        private float defaultWidth = 180f    ;
        private float minWidth     = 90f     ;
        private float maxWidth     = 540f    ;

        // 820x530 fullres
        private float imgDefaultWidth = 164f ; // 156
        private float imgMinWidth     = 0f  ; // 25
        private float imgMaxWidth     = 820f ; // 700

        public void OnHoverButton(ButtonID _btn)
        {
            switch (_btn)
            {
                case ButtonID.p1:
                    GrowButton(0);
                    title.text = "P1 | Playground";
                    break;

                case ButtonID.p2:
                    GrowButton(1);
                    title.text = "P2 | Tree Brief";
                    break;

                case ButtonID.p3:
                    GrowButton(2);
                    title.text = "P3 | Pivot Brief";
                    break;

                case ButtonID.p4:
                    GrowButton(3);
                    title.text = "Coming Soon...";
                    break;

                case ButtonID.p5:
                    GrowButton(4);
                    title.text = "Coming Soon...";
                    break;
            }
        }

        public void OnReleaseButton()
        {
            ResetAllButtons();
            title.text = "Select a Prototype";
        }

        public void ResetAllButtons()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                //DOTween.Kill(buttons[i]);
                buttons[i].GetComponent<RectTransform>().DOSizeDelta(new Vector2(defaultWidth, 280), 0.5f).SetUpdate(true);
                previews[i].GetComponent<RectTransform>().DOSizeDelta(new Vector2(imgDefaultWidth, 530), 0.5f).SetUpdate(true);
            }
        }

        private void GrowButton(int _id)
        {
            //DOTween.Kill(buttons[_id]);
            buttons[_id].GetComponent<RectTransform>().DOSizeDelta(new Vector2(maxWidth, 280), 0.5f).SetUpdate(true);
            previews[_id].GetComponent<RectTransform>().DOSizeDelta(new Vector2(imgMaxWidth, 530), 0.5f).SetUpdate(true);

            for (int i = 0; i < buttons.Count; i++)
            {
                if (i != _id) buttons[i].GetComponent<RectTransform>().DOSizeDelta(new Vector2(minWidth, 280), 0.5f).SetUpdate(true);
                if (i != _id) previews[i].GetComponent<RectTransform>().DOSizeDelta(new Vector2(imgMinWidth, 530), 0.5f).SetUpdate(true);
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

