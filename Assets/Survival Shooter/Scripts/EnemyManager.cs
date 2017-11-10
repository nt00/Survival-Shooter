using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyManager : NetworkBehaviour
{
    public Transform[] spawnPoints;         
    public GameObject[] enemyPrefabs;
    public int enemyCount = 5; 
    public float spawnWait = 0.5f;
    public float startWait = 1f;
    public float waveWait = 5f;
    private bool gameOver;

    public void Start()
    {
        gameOver = false;
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        // Waits after game starts before spawning waves
        yield return new WaitForSeconds(startWait);
        // Continously runs until game over
        while (!gameOver)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                // Spawn position is determined randomly on the x axis
                int spawnPointIndex = Random.Range(0, spawnPoints.Length);
                // Spawns random enemies
                int prefab_num = Random.Range(0, enemyPrefabs.Length);
                Instantiate(enemyPrefabs[prefab_num], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                yield return new WaitForSeconds(spawnWait);
            }
            // Waits after waves finishes before restarting
            yield return new WaitForSeconds(waveWait);
            // Add an extra enemy
            enemyCount += 1;
        }
    }
}
