using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public GameObject ball; // Reference to the ball GameObject
    public float powerUpDuration = 10f; // Duration of the power-up effect in seconds
    public float newBallSize = 0.1f; // New size of the ball during the power-up effect
    private Vector3 originalBallSize; // Original size of the ball

    public float fallSpeed = 5f;
    public AudioSource audioSource; // Reference to the AudioSource component
    void Start()
    {
        originalBallSize = ball.transform.localScale; // Store the original size of the ball
    }

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        // Check if power-up reached below the ring
        if (transform.position.y < 4)
        {
            Destroy(gameObject); // Destroy power-up when it is below the ring
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        // Check if the player's ball collided with the power-up
        if (other.gameObject.tag == "Ball")
        {
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play(); // Play the sound
            }
            // Activate the power-up effect
            StartCoroutine(ActivatePowerUp(other.gameObject));
        }
    }

    IEnumerator ActivatePowerUp(GameObject ball)
    {
        // Decrease the size of the ball
        ball.transform.localScale = new Vector3(newBallSize, newBallSize,newBallSize);

        // Wait for the duration of the power-up
        yield return new WaitForSeconds(powerUpDuration);

        // Restore the original size of the ball
        ball.transform.localScale = originalBallSize;

        Destroy(gameObject);
    }
}
