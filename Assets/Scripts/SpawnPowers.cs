using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowers : MonoBehaviour
{
    public GameObject[] powerPrefabs; // Array of power-up prefabs (power-ups and power-downs)
    public float spawnInterval = 15f; // Interval between power-up spawns

    void Start()
    {
        // Start the coroutine to spawn power-ups alternately
        StartCoroutine(SpawnPower());
    }

    IEnumerator SpawnPower()
    {
        while (true)
        {
            // Randomly select a power-up prefab from the array
            int randomIndex = Random.Range(0, powerPrefabs.Length);
            GameObject selectedPowerPrefab = powerPrefabs[randomIndex];

            // Instantiate the selected power-up prefab
            Instantiate(selectedPowerPrefab, GetRandomSpawnPosition(), Quaternion.identity);

            // Wait for the specified spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(0.94f,4.9f), 10f,0);
        return randomSpawnPosition;
    }
}
