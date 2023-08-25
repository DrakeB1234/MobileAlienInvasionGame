using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitMenu : MonoBehaviour
{
    public void ButtonPressed()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
}
