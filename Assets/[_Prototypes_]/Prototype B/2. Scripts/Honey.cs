using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Prototype2
{
    public class Honey : MonoBehaviour
    {
        private bool dying = false;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;
            other.GetComponent<PlayerControl>().GainHoney(10);
            dying = true;
            transform.DOScale(Vector3.zero, 2).onComplete = KillSelf;
        }

        private void KillSelf() => Destroy(gameObject);

        private void Update()
        {
            if (dying)
            {
                transform.Rotate(Vector3.up, (360 * Time.deltaTime));
            }
                
        }
    }
}

