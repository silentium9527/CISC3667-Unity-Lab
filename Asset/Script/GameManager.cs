using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    private int level = 1;
    [SerializeField] TextMeshProUGUI levelText;
    public int balloonCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        balloonCount = level;
        DisplayScore();
        DisplayLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (balloonCount == 0){
            if (level <= 3){
                SceneManager.LoadScene(level + 1);
            }else{
                SceneManager.LoadScene(4);
            }
        }
    }

    private void Awake()
    {
        if (gm == null){
            gm = this;
            //DontDestroyOnLoad(gameObject);
        } else if (gm != this){
            Destroy(gameObject);
        }
    }

    public void balloonDecrease()
    {
        balloonCount -= 1;
    }

    public void AddScore(int points)
    {
        score += points;
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = "Score: " + score;
    }

    private void DisplayLevel()
    {
        levelText.text = "Level: " + level;
    }
}
