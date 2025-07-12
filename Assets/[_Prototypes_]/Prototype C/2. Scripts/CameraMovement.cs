using DG.Tweening;
using Prototype3;
using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] private float delay;
    [SerializeField] private bool isFollowing = false;
    private Vector3 playerPos;
    private Vector3 initRotation;

    [Header("Panel")]
    [SerializeField] private GameObject roof;
    [SerializeField] private float roofSlideTime;


    private void Awake()
    {
        initRotation = transform.eulerAngles;
    }
    private void Start()
    {
        if (delay <= 0)
            delay = 3f;
        if (roofSlideTime <= 0)
            roofSlideTime = 0.7f;

        StartCoroutine(StartTimer(delay));
    }

    IEnumerator StartTimer(float _delay)
    {
        yield return new WaitForSeconds(_delay);

        Destroy(GetComponent<OldLookAtGameObject>());
        //transform.eulerAngles = initRotation;
        transform.DORotate(initRotation, 2.5f).OnComplete(() =>
        {
            StartCoroutine(RoofSlider());
        });
    }

    IEnumerator RoofSlider()
    {
        roof.transform.DOLocalMoveX(0, roofSlideTime).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            /*player.GetComponent<InputManager>().SetCanMove(true);*/
            StartCoroutine(SlowDeath());
        });
        yield return null;
    }

    IEnumerator SlowDeath()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(GetComponent<CameraMovement>());
    }
}
