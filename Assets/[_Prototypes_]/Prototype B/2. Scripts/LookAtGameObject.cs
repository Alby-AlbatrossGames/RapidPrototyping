using UnityEngine;

public class LookAtGameObject : MonoBehaviour
{
    [SerializeField] private string gameObjectName = "target";
    [SerializeField] private GameObject target = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.Find(gameObjectName);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
    }
}
