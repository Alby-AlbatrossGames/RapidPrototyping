using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PauseAnimator : MonoBehaviour
{
    public GameObject titleText;
    public GameObject menuButtons;

    private Vector3 titleStartPos;
    private Vector3 menuStartPos;
    private void Start()
    {

    }
    private void OnEnable()
    {
        titleStartPos = titleText.transform.position;
        menuStartPos = menuButtons.transform.position;
        StartCoroutine(EntryAnim());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
        DOTween.Kill(titleText);
        DOTween.Kill(menuButtons);
    }

    private IEnumerator EntryAnim()
    {
        titleText.transform.position = new Vector3 (titleStartPos.x + Screen.width, titleStartPos.y, titleStartPos.z);
        menuButtons.transform.position = new Vector3 (menuStartPos.x - Screen.width, menuStartPos.y, menuStartPos.z);
        titleText.transform.DOMoveX(titleStartPos.x, 0.5f).SetUpdate(true).SetEase(Ease.OutCirc).OnComplete(() => Debug.Log("Finished Animating PauseMenu Title"));
        menuButtons.transform.DOMoveX(menuStartPos.x, 0.5f).SetUpdate(true).SetEase(Ease.OutCirc).OnComplete(() => Debug.Log("Finished Animating PauseMenu Buttons"));
        yield return null;
    }
}
