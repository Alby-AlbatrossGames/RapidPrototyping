using UnityEngine;

public class ConstantRotate : MonoBehaviour
{
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;
    [SerializeField] private float zSpeed;
    [Header("Total Speed Multiplier")]
    [SerializeField] private int speedMulti = 1;
    private void Start()
    {
        xSpeed *= speedMulti;
        ySpeed *= speedMulti;
        zSpeed *= speedMulti;
    }



    private void Update() => transform.Rotate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
}
