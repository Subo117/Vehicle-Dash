using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public void PlayTap()
    {
        if (MusicSettingManager.instance != null)
            MusicSettingManager.instance.OnTapSound();
    }

    public void PlayBack()
    {
        if (MusicSettingManager.instance != null)
            MusicSettingManager.instance.OnBackSound();
    }
}
