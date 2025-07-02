using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float moveSpeed;
    public float maxSpeed = 5f;
    public float speedMultiplier = 1f;
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

        moveSpeed = speedMultiplier * maxSpeed;
        enemyRb.AddForce(lookDirection * moveSpeed);

        if (transform.position.y < -10) { Destroy(gameObject); }

        FreezeTimeEffect();
    }

    private Vector3 DirectionUpdater(bool _active = true)
    {
        return (player.transform.position - transform.position).normalized;
    }

    private void FreezeTimeEffect(float _duration = 3f)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Time Frozen");
            enemyRb.linearVelocity = Vector3.zero;
            StartCoroutine(FreezeSpeed(_duration));
        }
    }

    IEnumerator FreezeSpeed(float _duration)
    {
        float counter = 0f;
        while (counter < _duration)
        {
            counter += Time.deltaTime;
            speedMultiplier = 0.2f;
            Debug.Log("Enemy Speed: "+speedMultiplier);
            yield return null;
            speedMultiplier = 1f;
        }
    }
}