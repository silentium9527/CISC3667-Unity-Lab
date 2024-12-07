using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float jumpForce = 10f;
    public Transform pinSpawnPoint;
    public GameObject pinPrefab;

    private Rigidbody2D rb; 
    private bool facingRight = true;

    private Animator playerAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Jump
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

        float speedx = Mathf.Abs(rb.velocity.x);
        playerAnimator.speed = speedx / 10.0f;
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
        GameObject pin = Instantiate(pinPrefab, pinSpawnPoint.position, Quaternion.Euler(0, 0, 90));
        pin.GetComponent<Pin>().enabled = true;  // Activate the pin's movement
    }
}
