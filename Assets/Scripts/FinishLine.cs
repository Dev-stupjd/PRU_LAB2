using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        UIManager uiManager = FindObjectOfType<UIManager>();
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("FinalScore", uiManager.GetScore());
            PlayerPrefs.Save();

            finishEffect.Play();
            Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
