using System.Collections;
using UnityEngine;

public class MagnetPickup : MonoBehaviour
{
    [SerializeField] float secondsToWait = 5f;

    Magnet magnetManager;

    private void Awake()
    {
        magnetManager = FindAnyObjectByType<Magnet>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        magnetManager.ActivateMagnet(secondsToWait);
        
        Destroy(this.gameObject);
    }
    
}
