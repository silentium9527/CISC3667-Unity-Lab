using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;  // 单例模式

    public Text scoreText;  // 用于显示得分的UI文本
    private float score = 0f;  // 当前分数

    void Awake()
    {
        // 确保 GameManager 是唯一的
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // 更新得分显示
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    public void AddScore(float amount)
    {
        score += amount;  // 增加分数
    }
}
