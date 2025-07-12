using DG.Tweening;
using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float delay;
    [SerializeField] private bool isFollowing = false;
    private Vector3 playerPos;

    private Vector3 initRotation;

    private void Awake()
    {
        initRotation = transform.eulerAngles;
    }
    private void Start()
    {
        if (delay <= 0)
            delay = 3f;

        StartCoroutine(StartTimer(delay));
    }

    IEnumerator StartTimer(float _delay)
    {
        yield return new WaitForSeconds(_delay);

        Destroy(GetComponent<OldLookAtGameObject>());
        //transform.eulerAngles = initRotation;
        transform.DORotate(initRotation, 2.5f).OnComplete(() =>
        {
            Destroy(this);
        });
    }
}
