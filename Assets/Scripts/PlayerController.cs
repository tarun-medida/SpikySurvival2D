using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private GameManager gameManager; // Reference to the GameManager script
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            gameManager.AddScore(1); // Increase the score by 1 when the ball jumps.
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with a GameObject tagged as "Spike"
        if (collision.gameObject.CompareTag("Spike"))
        {
            // Stop the game when player is dead
            Time.timeScale = 0f;
            // Destroy the player GameObject
            Destroy(gameObject);
            
            // You can add other game over logic here, like displaying a game over screen, resetting the game, etc.
        }
    }
}