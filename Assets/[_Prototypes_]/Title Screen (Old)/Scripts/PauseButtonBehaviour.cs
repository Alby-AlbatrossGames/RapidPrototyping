using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonBehaviour : GameBehaviour
{
    public enum BtnName { Resume, Restart, Title, Quit };
    public BtnName buttonName;

    private PauseManager pauseManager;

    private int constantWidth = 920;
    private int initialHeight = 100;

    private Vector3 btnScale = new Vector2(920, 125);
    private float animTime = 0.3f;

    private Tweener btnTweener;
    private RectTransform rectSize;
    private TMP_Text btnText;
    private string label;

    private void Start()
    {
        pauseManager = FindFirstObjectByType<PauseManager>();
        btnText = GetComponentInChildren<TMP_Text>();
        rectSize = GetComponent<RectTransform>();

        label = btnText.text;
    }

    public void Select()
    {
        rectSize.DOSizeDelta(btnScale, animTime).SetEase(Ease.OutQuad).SetUpdate(true);
        ExecuteAfterFrames(3, () => btnText.text = label + " <");
    }

    public void Deselect()
    {
        btnText.text = label;
        rectSize.DOSizeDelta(new Vector2(920,100), animTime).SetEase(Ease.OutQuad).SetUpdate(true);
    }

    public void Submit()
    {
        Deselect();
        switch (buttonName)
        {
            case BtnName.Resume:
                Debug.Log("Resuming...");
                pauseManager.Resume();
                return;
            case BtnName.Restart:
                Debug.Log("Restarting...");
                pauseManager.ReloadActiveScene();
                return;
            case BtnName.Title:
                Debug.Log("Loading Title Screen...");
                pauseManager.LoadSceneByName("Title");
                return;
            case BtnName.Quit:
                Debug.Log("Quitting Application...");
                pauseManager.QuitApp();
                return;
        }
    }
}
