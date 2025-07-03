using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float loadDelay = 1f;

    UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            //player.DisableControls();


            int currentHealth = uiManager.GetHealth();
            uiManager.SetHealth(currentHealth - 1);
            Debug.Log("Head hit -1 health");

            if (currentHealth - 1 <= 0)
            {
                player.DisableControls();

                PlayerPrefs.SetInt("FinalScore", uiManager.GetScore());
                PlayerPrefs.Save();

                SceneManager.LoadScene("GameOver");
                return;
            }


            crashEffect.Play();
            //Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

