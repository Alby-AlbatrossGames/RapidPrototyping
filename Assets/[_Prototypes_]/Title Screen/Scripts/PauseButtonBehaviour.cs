using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonBehaviour : MonoBehaviour
{
    private int constantWidth = 920;
    private int initialHeight = 100;

    private Vector3 btnScale = new Vector2(920, 125);
    private float animTime = 0.3f;

    private Tweener btnTweener;
    private RectTransform rectSize;
    private TMP_Text btnText;
    private string label;

    private bool confirm;

    private void Start()
    {
        confirm = false;
        btnText = GetComponentInChildren<TMP_Text>();
        label = btnText.text;
        rectSize = GetComponent<RectTransform>();
    }

    public void Select()
    {
        rectSize.DOSizeDelta(btnScale, animTime).SetEase(Ease.OutQuad);
        if (!confirm)
            btnText.text = label + " <";
    }

    public void Deselect()
    {
        rectSize.DOSizeDelta(new Vector2(920,100), animTime).SetEase(Ease.OutQuad);
        if (!confirm)
            btnText.text = label;
    }

    public void Submit()
    {
        if (!confirm)
        {
            btnText.text = label + " < ?";
            confirm = true;
            return;
        }
        else
        {
            btnText.text = "Loading...";
        }
        
    }
}
