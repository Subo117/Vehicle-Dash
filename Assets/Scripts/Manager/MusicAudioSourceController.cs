using UnityEngine;

public class MusicAudioSourceController : MonoBehaviour
{
    public static MusicAudioSourceController Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    
}
