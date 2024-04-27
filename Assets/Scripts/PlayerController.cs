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
    public Transform centerPoint;  // The center point of the boundary
    public float radius = 2.0f;    // The radius of the boundary circle
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

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //    //gameManager.AddScore(1); // Increase the score by 1 when the ball jumps.
        //}
        //// Handle touch input
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    MovePlayer(touch.position);
        //}

        //// Handle mouse input for testing in the editor
        //if (Input.GetMouseButton(0))
        //{
        //    MovePlayer(Input.mousePosition);
        //}
        Vector3 inputPosition = GetInputPosition();

        if (inputPosition != Vector3.zero) // Checks if a valid input is detected
        {
            MovePlayer(inputPosition);
        }
    }
    // Retrieves the current position of touch or mouse input in world coordinates
    private Vector3 GetInputPosition()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));  // Ensure the Z position is properly adjusted for your camera setup
        }
        else if (Input.GetMouseButton(0))  // Fallback to mouse input if no touch is detected
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));  // Same Z adjustment as touch
        }

        return Vector3.zero;  // Return zero vector if no input is detected
    }

    //private void MovePlayer(Vector2 inputPosition)
    //{
    //    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(inputPosition);
    //    worldPosition.z = 0; // Ensure the player moves only in the 2D plane
    //    transform.position = Vector3.MoveTowards(transform.position, worldPosition, moveSpeed * Time.deltaTime);
    //}

    // Moves the player towards the input position, ensuring they do not exit the circular boundary
    private void MovePlayer(Vector3 inputPosition)
    {
        inputPosition.z = 0;  // Ensure the z-coordinate is zero for 2D gameplay

        // Calculate the distance from the center point to the input position
        float distance = Vector2.Distance(inputPosition, centerPoint.position);

        if (distance > radius)
        {
            // Player is outside the boundary, calculate a position on the boundary
            Vector3 fromCenterToInput = inputPosition - centerPoint.position;
            fromCenterToInput.Normalize();
            fromCenterToInput *= radius;
            transform.position = centerPoint.position + fromCenterToInput;
        }
        else
        {
            // Player is inside the boundary, update position directly
            transform.position = inputPosition;
        }
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