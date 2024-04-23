using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f; // Speed at which the player moves
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private GameManager gameManager; // Reference to the GameManager script
    public GameObject deadScreen;
    public AudioSource audioSource; // Reference to the AudioSource component
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
            //gameManager.AddScore(1); // Increase the score by 1 when the ball jumps.
        }
        // Handle touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            MovePlayer(touch.position);
        }

        // Handle mouse input for testing in the editor
        if (Input.GetMouseButton(0))
        {
            MovePlayer(Input.mousePosition);
        }
    }
    private void MovePlayer(Vector2 inputPosition)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(inputPosition);
        worldPosition.z = 0; // Ensure the player moves only in the 2D plane
        transform.position = Vector3.MoveTowards(transform.position, worldPosition, moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with a GameObject tagged as "Spike"
        if (collision.gameObject.CompareTag("Spike"))
        {
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play(); // Play the sound
            }
            StartCoroutine(DeadScreen(0.5f));
           
        }
    }
    IEnumerator DeadScreen(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        deadScreen.SetActive(true);
        // Destroy the player GameObject
        Destroy(gameObject);
        // Stop the game when player is dead
        Time.timeScale = 0f;
    }
}