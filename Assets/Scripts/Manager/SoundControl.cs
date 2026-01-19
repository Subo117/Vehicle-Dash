using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] Slider musicSlider;
    [SerializeField] TMP_Text musicText;
    [SerializeField] Slider sfxSlider;
    [SerializeField] TMP_Text sfxText;

    [Header("Audio Source")]
    [SerializeField] AudioSource musicAudioSource;


    void Start()
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
        sfxText.text = Mathf.RoundToInt(sfxVol * 100).ToString();
    }

    public void SetMusicVolume(float vol)
    {
        PlayerPrefs.SetFloat("Music", vol);
        if (MusicAudioSourceController.Instance != null)
        {
            MusicAudioSourceController.Instance.GetComponent<AudioSource>().volume = vol;
        }
        musicText.text = Mathf.RoundToInt(vol * 100).ToString();

    }

    public void SetSFXVolume(float vol)
    {
        PlayerPrefs.SetFloat("SFX", vol);
        sfxSlider.value = vol;
        sfxText.text = Mathf.RoundToInt(vol * 100).ToString();
    }
}
