using UnityEngine;

public class PinMovement : MonoBehaviour
{
    public float speed = 5f;
    public GameObject pinPrefab;
    
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Balloon"))
        {
            Destroy(other.gameObject);  // Destroy balloon
            Destroy(gameObject);        // Destroy pin
        }
    }
}
