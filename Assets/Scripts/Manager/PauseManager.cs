using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] AudioClip tapClip;
    [SerializeField] AudioClip crossClip;
    public void OnPause()
    {
        MusicSettingManager.instance.PlaySound(tapClip);
        Time.timeScale = 0f;
    }
    public void OnResume()
    {
        Time.timeScale = 1f;
        MusicSettingManager.instance.PlaySound(tapClip);
    }

    public void OnMainMenu()
    {
        Time.timeScale = 1f;
        MusicSettingManager.instance.PlaySound(crossClip);
        SceneManager.LoadScene(0);
    }
}
