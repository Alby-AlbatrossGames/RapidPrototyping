using DG.Tweening;
using UnityEngine;
using TMPro;

public class TweenFun : GameBehaviour
{
    public enum Dir { N, S, E, W }
    public GameObject player;
    [SerializeField] private float moveDist = 5f;
    private float _t = 3f;

    [Header("UI")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int scoreBonus = 150;
    [SerializeField] private int score = 0;
    [SerializeField] private Ease scoreEase;

    public void Start()
    {
        player.GetComponent<Renderer>().material.color = _SAVE.GetPlayerColor;
        score = _SAVE.GetHighscore;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { MovePlayer(Dir.E, _t); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { IncreaseScore(); }
    }
    private void MovePlayer(Dir _dir, float _time)
    {
        Vector3 _startPos = player.transform.localPosition;
        switch (_dir)
        {
            case Dir.E:
                player.transform.DOLocalMoveX(_startPos.x + moveDist, _time).OnComplete(()=> { Debug.Log("huzzah"); });
                ;
                break;
        }
    }

    private void IncreaseScore()
    {
        TweenX.TweenNumbers(scoreText, score, scoreBonus + scoreBonus, 3, scoreEase, "F0");
    }
}
