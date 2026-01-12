using UnityEngine;
using UnityEngine.Audio;

public class MusicSettingManager : MonoBehaviour
{

    public static MusicSettingManager instance;

    [SerializeField] AudioSource mainAudioSource;

    [SerializeField] AudioClip tapClip;
    [SerializeField] AudioClip crossClip;


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
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


    public void PlaySound(AudioClip clip)
    {
        AudioSource audioSource = Instantiate(mainAudioSource, transform.position, Quaternion.identity);
        audioSource.clip = clip;
        audioSource.Play();

        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);

    }


}
