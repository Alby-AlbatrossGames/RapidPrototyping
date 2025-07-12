using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype3
{
    public class RestartGame : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Marble"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
                // x 3  z 4.5
            }
        }
    }
}

