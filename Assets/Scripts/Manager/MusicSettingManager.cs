using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSettingManager : MonoBehaviour
{

    public static MusicSettingManager instance;

    [Header("Sliders")]
    [SerializeField] Slider musicSlider;
    [SerializeField] TMP_Text musicText;
    [SerializeField] Slider sfxSlider;
    [SerializeField] TMP_Text sfxText;

    [Header("Audiosources")]
    [SerializeField] AudioSource mainAudioSource;
    [SerializeField] AudioSource musicAudioSource;

    [Header("Clips")]
    [SerializeField] AudioClip tapClip;
    [SerializeField] AudioClip crossClip;
    [SerializeField] AudioClip purchaseClip;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetFloat("Music", 1f);
        }
        float musicVol = PlayerPrefs.GetFloat("Music");
        musicSlider.value = musicVol;
        musicAudioSource.volume = musicSlider.value;
        musicText.text = Mathf.RoundToInt(musicVol * 100).ToString();

        if (!PlayerPrefs.HasKey("SFX"))
        {
            PlayerPrefs.SetFloat("SFX", 1f);
        }
        float sfxVol = PlayerPrefs.GetFloat("SFX");
        sfxSlider.value = sfxVol;
        sfxText.text = Mathf.RoundToInt(musicVol * 100).ToString();

        DontDestroyOnLoad(musicAudioSource);

    }
    

    public void SetMusicVolume(float vol)
    {
        PlayerPrefs.SetFloat("Music", vol);
        musicAudioSource.volume = vol;

        musicSlider.value = vol;
        musicText.text = Mathf.RoundToInt(vol * 100).ToString();

    }
    public void SetSFXVolume(float vol)
    {
        PlayerPrefs.SetFloat("SFX", vol);
        sfxSlider.value = vol;
        sfxText.text = Mathf.RoundToInt(vol * 100).ToString();
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
