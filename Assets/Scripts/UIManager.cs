using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthText;

    int score = 0;
    int health = 3;

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void SetHealth(int value)
    {
        health = value;
        healthText.text = "Health: " + health;

        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public void ResetUI()
    {
        score = 0;
        health = 3;
        UpdateScore(0);
        SetHealth(3);
    }

    public int GetScore()
    {
        return score;
    }

}
