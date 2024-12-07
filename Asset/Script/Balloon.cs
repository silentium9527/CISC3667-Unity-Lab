using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balloon : MonoBehaviour
{
    private GameManager gm;

    public int balloonScore = 3;
    private float moveSpeed = 50f;
    private Vector2 moveDirection;

    private AudioSource audioSource;
    public float growAmount = 50f;
    private int growCount = 0;

    void Start()
    {
        // Initialize a random direction and speed at start
        SetRandomDirection();
        // Balloon increase size every 5s
        InvokeRepeating("Grow", 0f, 5f);
        audioSource = GetComponent<AudioSource>();
        if (gm == null){
            gm = FindObjectOfType<GameManager>();
        }
    }

    void Update()
    {
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
            GameManager.gm.AddScore(balloonScore);
            GameManager.gm.balloonDecrease();
             // Play the pop sound from the balloon
            audioSource.Play();
            // Destroy the balloon
            Destroy(gameObject); 
        }
    }

    void Grow()
    {
        if (growCount < 2)
        {
            // increase balloon size
            transform.localScale += new Vector3(growAmount, growAmount, 0);
            growCount++; 
            balloonScore--;
        }
        else
        {
            CancelInvoke("Grow");
        }
    }

}