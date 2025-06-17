using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody enemyRb;
    private GameObject player;
    private Vector3 lookDirection;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        lookDirection = DirectionUpdater();
    }

    private void Update()
    {
        if (player.GetComponent<PlayerController>().enemyCollision == false) {  }
        else { lookDirection = DirectionUpdater(); }

        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10) { Destroy(gameObject); }
    }

    private Vector3 DirectionUpdater(bool _active = true)
    {
        return (player.transform.position - transform.position).normalized;
    }
}
