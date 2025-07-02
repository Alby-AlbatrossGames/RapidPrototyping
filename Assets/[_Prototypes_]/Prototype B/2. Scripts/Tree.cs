using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Prototype2
{
    public class Tree : MonoBehaviour
    {
        public GameObject beePrefab;
        public List<GameObject> spawnList;
        [SerializeField] private float spawnDelay;

        private void Start()
        {
            if (spawnDelay <= 0)
                    spawnDelay = 1f;
            StartCoroutine(spawnTimer());
        }

        private IEnumerator spawnTimer()
        {
            SpawnBee();
            yield return new WaitForSeconds(spawnDelay);
            StartCoroutine(spawnTimer());
        }

        void SpawnBee()
        {
            Transform spawn = GetSpawnPos();
            Instantiate(beePrefab, spawn.position, spawn.rotation);
        }

        Transform GetSpawnPos()
        {
            return spawnList[ Random.Range( 0, (spawnList.Count-1) )].transform;
        }
    }
}

