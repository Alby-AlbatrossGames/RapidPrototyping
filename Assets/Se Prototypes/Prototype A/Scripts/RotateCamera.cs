using UnityEngine;
using UnityEngine.UI;

public class RotateCamera : MonoBehaviour
{
    private float rotationSpeed;
    private bool canRotate = true;
    public GameObject camSlider;

    private void Start()
    {
        rotationSpeed = PlayerPrefs.GetFloat("camRotationSpeed");
        UpdateSpeed();
    }

    private void Update()
    {
        if (canRotate)
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    public void ToggleRotate() { canRotate = !canRotate; }

    public void UpdateSpeed() 
    { 
        rotationSpeed = camSlider.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("camRotationSpeed", rotationSpeed);
        Debug.Log("Set PlayerPref [camRotationSpeed] to [" + (PlayerPrefs.GetFloat("camRotationSpeed")) + "]");
        Debug.Log("Cam Speed Set To: " + rotationSpeed);
    }
}
