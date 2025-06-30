using UnityEngine;

public class EnemyBee : MonoBehaviour
{
    [SerializeField] private float beeSpeed;

    private void Start()
    {
        beeSpeed = 5;
    }
    void Update()
    {
        MoveBee();
    }

    void MoveBee() { gameObject.transform.position += transform.forward * beeSpeed * Time.deltaTime; }
}
