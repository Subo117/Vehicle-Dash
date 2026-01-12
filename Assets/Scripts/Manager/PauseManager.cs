using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public void OnPause()
    {
        Time.timeScale = 0f;
        MusicSettingManager.instance.OnTapSound();
    }
    public void OnResume()
    {
        Time.timeScale = 1f;
        MusicSettingManager.instance.OnTapSound();
    }

    public void OnMainMenu()
    {
        Time.timeScale = 1f;
        MusicSettingManager.instance.OnBackSound();
        SceneManager.LoadScene(0);
    }
}
