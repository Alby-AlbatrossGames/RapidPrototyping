using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using ACX;

namespace Prototype2
{
    public class BeeTree : MonoBehaviour
    {
        public GameObject beePrefab;
        public GameObject honeyPrefab;
        public List<GameObject> spawnList;
        [SerializeField] private float spawnDelay;

        private void Start()
        {
            if (spawnDelay <= 0)
                spawnDelay = 1f;
            StartCoroutine(SpawnTimer());
        }

        private IEnumerator SpawnTimer()
        {
            int x = Random.Range(0, 2);

            if (x == 0)
                Spawn(beePrefab);
            if (x == 1)
                Spawn(honeyPrefab);
            yield return new WaitForSeconds(spawnDelay);
            StartCoroutine(SpawnTimer());
        }

        Transform GetSpawnPos()
        {
            return spawnList[ Random.Range( 0, (spawnList.Count-1) )].transform;
        }

        void Spawn(GameObject _obj)
        {
            AC.ACLog("Spawning [" + _obj.name + "]", this.GetType().FullName);
            Transform spawn = GetSpawnPos();
            Instantiate(_obj, spawn.position, spawn.rotation);
        }
    }
}

