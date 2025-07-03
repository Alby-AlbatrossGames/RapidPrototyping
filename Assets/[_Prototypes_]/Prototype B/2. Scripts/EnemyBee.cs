using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Prototype2
{
    public class EnemyBee : GameBehaviour
    {
        [SerializeField] private float curBeeSpeed;
        [SerializeField] public float maxBeeSpeed = 7;
        [SerializeField] private float bumpTime;
        private int slideDir = 1;

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

        void SlideBee(int _dir) => gameObject.transform.position +=  (transform.right * _dir) * curBeeSpeed * Time.deltaTime;

       /* void OnHitPlayer(GameObject _bee)
        {
            if (_bee == this.gameObject)
            {
                StartCoroutine(MoveBeeBack());
                //Damage Player
            }
        }*/

        private IEnumerator MoveBeeBack()
        {
            curBeeSpeed = (-maxBeeSpeed / 2);

            yield return new WaitForSeconds(bumpTime);
            curBeeSpeed = curBeeSpeed / 2;

            yield return new WaitForSeconds(bumpTime);
            curBeeSpeed = maxBeeSpeed / 2;

            yield return new WaitForSeconds(bumpTime);
            curBeeSpeed = maxBeeSpeed;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Bee"))
            {
                Debug.Log("Bee Bumped");
                SlideBee(slideDir);
                //transform.position += (other.transform.position - transform.position).normalized * curBeeSpeed * Time.deltaTime;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(MoveBeeBack());
            }     
            
            if (other.CompareTag("Bee"))
                slideDir = Random.Range(-1, 1);
            //GameEvents.ReportOnBeeHitPlayer(this.gameObject);

            //if (other.CompareTag("Bee"))
                //transform.DOMove(facingAway * 2, 1f);
                //transform.DOMove((transform.position - (other.transform.position - transform.position).normalized) * 3, 0.5f);
            //transform.DOMove((other.transform.position - this.transform.position), 0.3f);
        }

        #region EventListeners
/*        private void OnEnable()
        {
            GameEvents.OnBeeHitPlayer += OnHitPlayer;
        }
        private void OnDisable()
        {
            GameEvents.OnBeeHitPlayer -= OnHitPlayer;
        }*/
        #endregion EventListeners
    }
}

