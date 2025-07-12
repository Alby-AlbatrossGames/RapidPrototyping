using UnityEngine;

    public class OldLookAtGameObject : MonoBehaviour
    {
        [SerializeField] private string gameObjectName = "target";
        [SerializeField] private GameObject target = null;

    void Start()
    {
        if (target == null)
            target = GameObject.Find(gameObjectName); // Find Target
    }

        void Update() => transform.LookAt(target.transform); //Look At Target Every Frame
    }

