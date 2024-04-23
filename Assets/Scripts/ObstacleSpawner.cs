using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Prefab of the obstacle to spawn
    public Transform[] spawnPoints; // Array of spawn points
    public float spawnInterval = 2f; // Interval between each spawn
    public float initialDelay = 1f; // Initial delay before spawning starts

    //private float timeSinceLastSpawn = 0f;

    void Start()
    {
        // Invoke the SpawnObstacle method after initialDelay seconds and repeat every spawnInterval seconds
        InvokeRepeating("SpawnObstacle", initialDelay, spawnInterval);
    }

    void SpawnObstacle()
    {
        // Choose a random spawn point from the array
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the obstacle at the chosen spawn point
        Instantiate(obstaclePrefab, randomSpawnPoint.position, Quaternion.identity);
    }
}
