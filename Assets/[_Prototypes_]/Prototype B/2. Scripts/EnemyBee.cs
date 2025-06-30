using DG.Tweening;
using System.Collections;
using UnityEngine;

public class EnemyBee : GameBehaviour
{
    [SerializeField] private float curBeeSpeed;
    [SerializeField] public float maxBeeSpeed = 7;
    [SerializeField] private float bumpTime;
    [SerializeField] private bool bumped = false;
    [SerializeField] private bool speedingUp = false;

    private void Start()
    {
        curBeeSpeed = maxBeeSpeed;
        bumpTime = 0.7f;
    }
    void Update()
    {
        MoveBee();

        /*if (bumped)
            curBeeSpeed = Mathf.Lerp(-maxBeeSpeed,0, bumpTime);*/
        /*if (speedingUp)
            curBeeSpeed = Mathf.Lerp(0, maxBeeSpeed, 0.5f);*/
    }

    void MoveBee() { gameObject.transform.position += transform.forward * curBeeSpeed * Time.deltaTime; }

    void OnHitPlayer(GameObject _bee)
    {
        Debug.Log("A Bee Hit The Player!");
        StartCoroutine(UpdateBeeSpeed());
        
        /*transform.DOLocalMove((gameObject.transform.localPosition - new Vector3(bumpDist,0)), bumpTime);*/
    }

    private IEnumerator UpdateBeeSpeed() 
    {
        /*bumped = true;*/
        curBeeSpeed = (-maxBeeSpeed / 2);
        Debug.Log("Phase 1 (On Hit)");
        yield return new WaitForSeconds(bumpTime);
        /*bumped = false;
        speedingUp = true;*/
        curBeeSpeed = curBeeSpeed / 2;
        Debug.Log("Phase 2 (1.3s later)");
        yield return new WaitForSeconds(0.5f);
        /*speedingUp = false;*/
        curBeeSpeed = maxBeeSpeed / 2;
        Debug.Log("Phase 3 (0.5s later)");
        yield return new WaitForSeconds(0.5f);
        curBeeSpeed = maxBeeSpeed;
        Debug.Log("Phase 4 (0.5s later");

    }

    private void OnTriggerEnter(Collider other)
    {
        GameEvents.ReportOnBeeHitPlayer(this.gameObject);
    }
    #region EventListeners
    private void OnEnable()
    {
        GameEvents.OnBeeHitPlayer += OnHitPlayer;
    }
    private void OnDisable()
    {
        GameEvents.OnBeeHitPlayer -= OnHitPlayer;
    }
    #endregion EventListeners
}
