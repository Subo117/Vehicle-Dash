using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSettingManager : MonoBehaviour
{

    public static MusicSettingManager instance;

    
    [Header("Audiosources")]
    [SerializeField] AudioSource mainAudioSource;

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

        Destroy(audioSource.gameObject, clip.length);

    }


}
