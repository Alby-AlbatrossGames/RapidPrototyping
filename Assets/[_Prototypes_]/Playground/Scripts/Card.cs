using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private TMP_Text ID;
    [SerializeField] private TMP_Text cardVal;
    [SerializeField] private TMP_Text cardDesc;
    [SerializeField] private TMP_Text cardSuite;
    [SerializeField] private SpriteRenderer cardIcon;
    [SerializeField] private Renderer cardRenderer;

    private CardData cd;

    public void Initialize(CardData _CD)
    {
        cd = _CD;
        ID.text = cd.cardID.ToString();
        cardVal.text = cd.value.ToString();
        cardDesc.text = cd.desc;
        cardSuite.text = cd.suite.ToString();
        cardIcon.sprite = cd.icon;
        cardRenderer.material.color = cd.colour;

        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBounce);
    }
}
