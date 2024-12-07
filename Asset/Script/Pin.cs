using UnityEngine;

public class Pin : MonoBehaviour
{
    public float speed = 60f;
    public GameObject pinPrefab;
    
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Balloon"))
        {
            // Score counting
            //int score = other.GetComponent<Balloon>().GetScoreBasedOnSize();
            //ScoreManager.AddScore(score);  // add score

            //Destroy(other.gameObject);  // Destroy balloon
            Destroy(gameObject);        // Destroy pin
        }
        else if (other.CompareTag("Block")){
            Destroy(gameObject);
        }
    }
}