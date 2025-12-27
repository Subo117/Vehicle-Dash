using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public void OnPause()
    {
        Time.timeScale = 0f;
    }
    public void OnResume()
    {
        Time.timeScale = 1f;
    }

    public void OnMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
