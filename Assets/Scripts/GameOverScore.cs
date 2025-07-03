using TMPro;
using UnityEngine;

public class GameOverScore : MonoBehaviour
{
     [SerializeField] TextMeshProUGUI scoreText; 

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        scoreText.text = "Score: " + finalScore.ToString();
    }
}
