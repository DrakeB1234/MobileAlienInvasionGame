using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void ButtonPressed()
    {
        SceneManager.LoadScene("Desert");
    }
}
