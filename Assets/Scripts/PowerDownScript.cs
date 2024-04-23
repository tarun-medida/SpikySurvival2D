using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDownScript : MonoBehaviour
{
    public GameObject ball; // Reference to the ball GameObject
    public float powerDownDuration = 10f; // Duration of the power-down effect in seconds
    public float newBallSize = 0.3f; // New size of the ball during the power-down effect
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
        // Check if power-down is below the ring
        if (transform.position.y < 4)
        {
            Destroy(gameObject); // Destroy power-down it reaches below the ring
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
        // Increase the size of the ball
        ball.transform.localScale = new Vector3(newBallSize, newBallSize,newBallSize);

        // Wait for the duration of the power-down
        yield return new WaitForSeconds(powerDownDuration);

        // Restore the original size of the ball
        ball.transform.localScale = originalBallSize;
        Destroy(gameObject);

    }
}
