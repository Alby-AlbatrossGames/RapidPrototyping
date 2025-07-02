using System.Collections;
using UnityEngine;

namespace Prototype2
{
    public class EnemyBee : GameBehaviour
    {
        [SerializeField] private float curBeeSpeed;
        [SerializeField] public float maxBeeSpeed = 7;
        [SerializeField] private float bumpTime;

        private void Start()
        {
            curBeeSpeed = maxBeeSpeed;
            bumpTime = 0.7f;
        }
        void Update()
        {
            MoveBee();
        }

        void MoveBee() => gameObject.transform.position += transform.forward * curBeeSpeed * Time.deltaTime;

        void OnHitPlayer(GameObject _bee)
        {
            StartCoroutine(UpdateBeeSpeed());
        }

        private IEnumerator UpdateBeeSpeed()
        {
            curBeeSpeed = (-maxBeeSpeed / 2);

            yield return new WaitForSeconds(bumpTime);
            curBeeSpeed = curBeeSpeed / 2;

            yield return new WaitForSeconds(bumpTime);
            curBeeSpeed = maxBeeSpeed / 2;

            yield return new WaitForSeconds(bumpTime);
            curBeeSpeed = maxBeeSpeed;
        }

        private void OnTriggerEnter(Collider other)
        {
            GameEvents.ReportOnBeeHitPlayer(this.gameObject);
        } // Report OnBeeHitPlayer Event

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
}

