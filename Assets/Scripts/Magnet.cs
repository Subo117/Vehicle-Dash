using System.Collections;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] GameObject coinCollector;
    Coroutine magnetCoroutine;

    public void ActivateMagnet(float secToWait)
    {
        if(magnetCoroutine != null)
        {
            StopCoroutine(magnetCoroutine);
        }
        magnetCoroutine = StartCoroutine(MagnetRoutine(secToWait));
    }

    public bool CollectorIsActive()
    {
        return coinCollector.activeInHierarchy;
    }
    
    IEnumerator MagnetRoutine(float secToWait)
    {
        coinCollector.SetActive(true);
        Debug.Log("Enabled");
        yield return new WaitForSeconds(secToWait);
        coinCollector.SetActive(false);
        Debug.Log("Disabled");

    }
    
}
