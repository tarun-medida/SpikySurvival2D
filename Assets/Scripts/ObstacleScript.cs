using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class ObstacleScript : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the obstacle moves

    private Transform player; // Reference to the player's transform
    private Vector3 direction;

    void Start()
    {
        // Find the player GameObject by tag
        player = GameObject.FindGameObjectWithTag("Ball").transform;

        // Ensure the player GameObject is found
        if (player == null)
        {
            Debug.LogError("Player GameObject not found. Make sure it has the 'Ball' tag.");
            return;
        }
        // Calculate the direction vector from the obstacle to the player
        direction = (player.position - transform.position).normalized;
        // Start moving the obstacle towards the player
    }
    void Update()
    {
        // Move the obstacle in the calculated direction
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

}
