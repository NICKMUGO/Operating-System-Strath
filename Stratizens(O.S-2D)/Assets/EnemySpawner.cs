using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy prefab to spawn
    public Transform SpawnPoint; // Spawn location
    public Transform player; // Reference to the player
    public int totalEnemiesToSpawn = 8;
    public float spawnInterval = 5f; // Time between spawns

    private int enemiesSpawned = 0;

    void Start()
    {
        if (SpawnPoint == null)
{
    Debug.LogError("SpawnPoint is not assigned!");
    return;
}

        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (enemiesSpawned < totalEnemiesToSpawn)
        {
            SpawnEnemy();
            enemiesSpawned++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        // Instantiate the enemy at the spawn point
        GameObject spawnedEnemy = Instantiate(enemyPrefab, SpawnPoint.position, Quaternion.identity);

        // Assign the player's Transform to the enemy
        Enemy enemyScript = spawnedEnemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.SetTarget(player);
        }

        Debug.Log("Enemy Spawned and Target Assigned");
    }


    
}
