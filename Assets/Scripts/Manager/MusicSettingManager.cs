using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class MusicSettingManager : MonoBehaviour
{

    public static MusicSettingManager instance;

    [SerializeField] AudioSource mainAudioSource;
    [SerializeField] AudioSource musicAudioSource;

    [SerializeField] AudioClip tapClip;
    [SerializeField] AudioClip crossClip;
    [SerializeField] AudioClip purchaseClip;



    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        musicAudioSource.volume = PlayerPrefs.GetFloat("Music");
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
    public void OnPurchaseSound()
    {
        PlaySound(purchaseClip);
    }
    


    public void PlaySound(AudioClip clip)
    {
        AudioSource audioSource = Instantiate(mainAudioSource, transform.position, Quaternion.identity);
        audioSource.clip = clip;
        audioSource.volume = PlayerPrefs.GetFloat("SFX");

        audioSource.Play();

        DontDestroyOnLoad(audioSource);

        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);

    }


}
