using BV;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

public class PlayerController : GameBehaviour
{
    public UnityEvent FreezeTime = null;

    public float speed = 5f;
    public Rigidbody playerRb;
    private GameObject fwdDirection;

    private float powerupStrength = 15f;

    public float powerupDuration = 7f;
    public float ghostDuration = 3f;

    public GameObject powerupIndicator;
    public GameObject ghostIndicator;

    public bool hasPowerup;
    public bool hasGhost;

    private Color visibleColor = new Color(0f, 1f, 0f, 1f);
    private Color invisibleColor = new Color(0f, 1f, 0f, 0.1f);
    private MeshRenderer playerMeshRenderer;

    public bool enemyCollision = true;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        fwdDirection = GameObject.Find("CamDirection");
        playerMeshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(fwdDirection.transform.forward * speed * forwardInput);
        playerRb.AddForce(fwdDirection.transform.right * speed * horizontalInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        ghostIndicator.transform.position = transform.position + new Vector3(0, 0.5f, 0);

        if (!enemyCollision)
        {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }

        if (transform.position.y < -30) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            Destroy(GameObject.FindWithTag("ghost"));
            StartCoroutine(PowerupCountDownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
        if (other.CompareTag("ghost"))
        {
            hasGhost = true;
            Destroy(other.gameObject);
            Destroy(GameObject.FindWithTag("powerup"));
            StartCoroutine(GhostCountDownRoutine());
            ghostIndicator.gameObject.SetActive(true);
            playerMeshRenderer.material.color = invisibleColor;
            enemyCollision = false;
        }
    }

    IEnumerator PowerupCountDownRoutine()
    {
        yield return new WaitForSeconds(powerupDuration);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    IEnumerator GhostCountDownRoutine()
    {
        yield return new WaitForSeconds(ghostDuration);
        hasGhost = false;
        ghostIndicator.gameObject.SetActive(false);
        playerMeshRenderer.material.color = visibleColor;
        enemyCollision = true;
    }

    /*public void FreezeAbility()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FreezeTime?.Invoke();
            Debug.Log("Time Frozen");
            //Set Enemy Momentum to 0 AND reduce speed, increasing back to normal over 5s
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with " + collision.gameObject.name + " with PowerUp[" + hasPowerup + "]");
            enemyRigidBody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
