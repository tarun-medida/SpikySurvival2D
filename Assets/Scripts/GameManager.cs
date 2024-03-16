using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro text component
    private int score = 0; // Player score
    private int lastScore = 0; // Last score at which a spike was spawned
    public GameObject spikePrefab; // Reference to the spike prefab
    public int initialNumberOfSpikes = 1; // Initial number of spikes
    public float spawnRadius = 2f; // Radius around the player where spikes can spawn
    private Transform ringCenterTransform; // Reference to the player's transform
    private GameObject[] previousSpikes; // Array to store references to previously spawned spikes
    public PlayzoneRotation ringPrefab;

    public GameObject pauseScreen;
    public int scorePerSecond = 1; // Score to add per second

    void Start()
    {
        StartCoroutine(IncreaseScore());
        ringCenterTransform = GameObject.FindGameObjectWithTag("Center").transform; // Find the player GameObject and get its transform
        //Initialize with 1 spike.
        SpawnSpike();
        // Initialize the score text
        UpdateScoreText();
    }
    private void Update()
    {
        // Example: Check for score increment and spawn spike if score increased by exactly 10
        if (score - lastScore >= 10)
        {
            DestroyPreviousSpikes(); // Destroy previous spikes
            SpawnSpike();
            lastScore += 10;
            ringPrefab.rotationSpeed += 25;
        }
        // Check for user input to toggle pause/resume
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    IEnumerator IncreaseScore()
    {
        while (true)
        {
            // Add scorePerSecond to the score every second
            score += scorePerSecond;

            // Update the score text
            UpdateScoreText();

            // Wait for one second
            yield return new WaitForSeconds(1f);
        }
    }

    public void Resume()
    {
        // Unpause the game
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }
    public void Exit()
    {
        // Quit the application 
        Application.Quit();
    }
    public void PlayAgain()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    void SpawnSpike()
    {
        int numberOfSpikes = Mathf.FloorToInt((score + 10) / 10); // Calculate the total number of spikes
        float angleStep = 360f / numberOfSpikes; // Calculate the angle step between each spike

        previousSpikes = new GameObject[numberOfSpikes]; // Initialize array to store references to previously spawned spikes

        for (int i = 0; i < numberOfSpikes; i++)
        {
            float angle = i * angleStep; // Calculate the angle for this spike
            // Convert the angle to radians and calculate the spawn position
            Vector3 spawnPosition = ringCenterTransform.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * spawnRadius;
            // Calculate direction vector from spike position to player position
            Vector3 directionToPlayer = (ringCenterTransform.position - spawnPosition).normalized;

            // Calculate rotation to point towards the center
            Quaternion rotationToCenter = Quaternion.LookRotation(Vector3.forward, directionToPlayer);

            // Instantiate the spike prefab at the spawn position with rotation towards the center
            previousSpikes[i] = Instantiate(spikePrefab, spawnPosition, rotationToCenter);
            // Set the player's ring as the parent of the spawned spike
            previousSpikes[i].transform.parent = ringCenterTransform;
        }
    }
    void DestroyPreviousSpikes()
    {
        // Destroy previously spawned spikes
        if (previousSpikes != null)
        {
            foreach (GameObject spike in previousSpikes)
            {
                Destroy(spike);
            }
        }
    }

    // Call this method whenever the player's score changes
    //public void AddScore(int scoreToAdd)
    //{
    //    score += scoreToAdd;
    //    UpdateScoreText();
    //}

    // Update the score text component
    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
