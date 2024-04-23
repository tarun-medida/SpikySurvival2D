using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class ObstacleScript : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the obstacle moves

    private Transform player; // Reference to the player's transform
    private Vector3 direction;
    //public float destroyDistance = 0.5f; // Distance to destroy the obstacle
    //public float rotateSpeed = 50f; // Speed at which the obstacle rotates
    private float destroyObject = 5f;

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
        Invoke("DestroyObstacle", destroyObject);
    }
    void Update()
    {
        //// Rotate the obstacle around its own axis
        //transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        // Move the obstacle in the calculated direction
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        // Check the distance between the obstacle and the player
        //float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        //// If the distance exceeds the destroyDistance, destroy the obstacle
        //if (distanceToPlayer > destroyDistance)
        //{
        //    Destroy(gameObject);
        //}
    }
    void DestroyObstacle()
    {
        Destroy(gameObject);
    }
}
