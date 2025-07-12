using Unity.VisualScripting;
using UnityEngine;

namespace Prototype3
{
    public class Player : MonoBehaviour
    {
        public GameObject respawnPoint;
        private void Update()
        {
            if (transform.position.y < -10)
            {
                transform.position = respawnPoint.transform.position;
                GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            }
        }
    }
}

