using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public GameObject pinPrefab;  // Reference to the pin prefab
    public Transform pinSpawnPoint; // Point where the pin should spawn

    private Rigidbody2D rb;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Jump (upward movement)
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Flip the sprite when direction changes
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        // Shooting pins
        if (Input.GetButtonDown("Fire1"))
        {
            ShootPin();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void ShootPin()
    {
        // Instantiate the pin at the player's position
        GameObject pin = Instantiate(pinPrefab, pinSpawnPoint.position, Quaternion.identity);
        pin.GetComponent<PinMovement>().enabled = true;  // Activate the pin's movement
    }
}
