using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1"); 
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
