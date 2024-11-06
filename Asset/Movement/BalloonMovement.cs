using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    private float moveSpeed = 2f;
    private Vector2 moveDirection;

    public AudioClip popSound;  // Reference to the pop sound clip
    private AudioSource audioSource;

    void Start()
    {
        // Initialize a random direction and speed at start
        SetRandomDirection();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("Balloon does not have an AudioSource component!");
        }
    }

    void Update()
    {
        // Move the balloon in the current direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Check if the balloon reaches screen edges, and change direction if it does
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x <= 0 || screenPos.x >= Screen.width || screenPos.y <= 0 || screenPos.y >= Screen.height)
        {
            SetRandomDirection();
        }
    }

    void SetRandomDirection()
    {
        // Set a random direction
        float randomAngle = Random.Range(0f, 360f);
        moveDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)).normalized;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the balloon collided with the pin
        if (other.CompareTag("Pin"))
        {
             // Play the pop sound from the balloon
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }

            // Destroy the balloon after the sound is played
            Destroy(gameObject, popSound.length);  
        }
    }
}
