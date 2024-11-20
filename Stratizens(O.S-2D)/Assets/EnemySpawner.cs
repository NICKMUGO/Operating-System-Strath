// using System.Collections;
// using System.Collections.Generic;
// using System.Diagnostics;
// using UnityEngine;

// [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
// public class EnemySpawner : MonoBehaviour
// {


//     public GameObject enemyPrefab;
//     public Transform spawnPoint;
//     public Transform player;


//     public float spawnRate = 5f;
//     // Start is called before the first frame update
//     void Start()
//     {
//         StartCoroutine(SpawnEnemy());
//     }

// IEnumerator SpawnEnemy()
// {
//      while (true)
//     {
//         SpawnEnemyInstance();
//         yield return new WaitForSeconds(spawnRate); // Wait before spawning the next enemy
//     }
// }
// void SpawnEnemyInstance()
// {
//     GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
//     Enemy enemyScript = enemy.GetComponent<Enemy>();

//     if(enemyScript != null)
//     {
//         enemyScript.SetTarget(player);
//     }
// }

// public void SetTarget(Transform player)
// {
//     this.player = player;
// }

//     private string GetDebuggerDisplay()
//     {
//         return ToString();
//     }
// }
