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


    void Start()
    {
        float musicVol = PlayerPrefs.GetFloat("Music", 1f);
        musicSlider.value = musicVol;
        musicText.text = Mathf.RoundToInt(musicVol * 100).ToString();

        if (MusicAudioSourceController.Instance != null)
        {
            MusicAudioSourceController.Instance.GetComponent<AudioSource>().volume = musicVol;
        }

        float sfxVol = PlayerPrefs.GetFloat("SFX", 1f);
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
