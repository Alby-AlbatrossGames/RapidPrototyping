using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    public int enemiesPerWave = 3;
    public int activeEnemyCount;

    public int waveNumber = 1;
    public GameObject powerupPrefab;
    public GameObject ghostPrefab;

    private void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerups();
    }

    private void SpawnPowerups()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        Instantiate(ghostPrefab, GenerateSpawnPosition(), ghostPrefab.transform.rotation);
    }

    private void Update()
    {
        activeEnemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (activeEnemyCount == 0) 
        { 
            waveNumber++;
            Destroy(GameObject.FindWithTag("powerup"));
            Destroy(GameObject.FindWithTag("ghost"));
            SpawnEnemyWave(waveNumber);
            SpawnPowerups();
        }
    }

    void SpawnEnemyWave(int _enemiesToSpawn = 1)
    {
        for (int i = 0; i < _enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
