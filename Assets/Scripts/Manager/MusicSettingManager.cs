using UnityEngine;
using UnityEngine.Audio;

public class MusicSettingManager : MonoBehaviour
{

    public static MusicSettingManager instance;

    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip tapClip;
    [SerializeField] AudioClip crossClip;


    private void Awake()
    {
        instance = this;
    }

    public void SetMusicVolume(float vol)
    {
        PlayerPrefs.SetFloat("Music", vol);
        
    }
    public void SetSFXVolume(float vol)
    {
        PlayerPrefs.SetFloat("SFX", vol);

    }

    public void OnTapSound()
    {
        PlaySound(tapClip);
    }
    public void OnBackSound()
    {
        PlaySound(crossClip);
    }


    void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();

    }


}
