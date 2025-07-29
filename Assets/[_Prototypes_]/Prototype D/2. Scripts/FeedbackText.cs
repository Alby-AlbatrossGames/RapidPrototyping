using DG.Tweening;
using Prototype4;
using TMPro;
using UnityEngine;

public class FeedbackText : MonoBehaviour
{
    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }
    public void Initialize(Vector3 startPos, string txt, Color clr)
    {
        text.text = txt;
        text.color = clr;
        transform.position = startPos;
        transform.DOLocalMoveY(transform.position.y + 20, 0.5f).OnComplete(() => gameObject.SetActive(false));
    }
}
