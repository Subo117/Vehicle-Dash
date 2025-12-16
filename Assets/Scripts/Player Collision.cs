using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] float timeToWait = 10f;
    [SerializeField] GameObject coinCollector;

    PlayerControl playerControl;
    ScoreManager scoreManager;
    CoinMove coinMove;


    public bool isCrashed = false;
    bool isShieldActive = false;
    bool isTwiceCoinActive = false;

    Coroutine shieldCoroutine;
    Coroutine magnetCoroutine;
    Coroutine twiceCoinCoroutine;

    private void Start()
    {
        playerControl = GetComponentInParent<PlayerControl>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            if(isShieldActive)
            {
                isCrashed = false;
                playerControl.isMovable = true;
                Destroy(collision.gameObject);
            }
            else
            {
                isCrashed = true;
                playerControl.isMovable = false;

            }
        }
        else if (collision.gameObject.CompareTag("Shield"))
        {
            Debug.Log("Shield collider");
            Debug.Log(collision.gameObject.name);
            if(shieldCoroutine != null)
            {
                StopCoroutine(shieldCoroutine);
            }
            shieldCoroutine =  StartCoroutine(ShieldCoroutine(collision));
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            if (isTwiceCoinActive) scoreManager.IncreaseScore(2);
            else scoreManager.IncreaseScore(1);

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Magnet"))
        {
            Debug.Log("magnet collider");
            if (magnetCoroutine != null)
            {
                StopCoroutine(magnetCoroutine);
            }
            magnetCoroutine = StartCoroutine(MagnetRoutine());
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("TwiceCoin"))
        {
            if(twiceCoinCoroutine != null)
            {
                StopCoroutine (twiceCoinCoroutine);
            }
            twiceCoinCoroutine = StartCoroutine(TwiceCoinCoroutine(collision));
        }
    }

    IEnumerator ShieldCoroutine(Collision collision)
    {
        isShieldActive = true;
        Destroy(collision.gameObject);
        yield return new WaitForSeconds(timeToWait);
        isShieldActive = false;
    }

    IEnumerator TwiceCoinCoroutine(Collision collision)
    {
        isTwiceCoinActive = true;
        Destroy(collision.gameObject);
        yield return new WaitForSeconds(timeToWait);
        isTwiceCoinActive = false;
    }

    IEnumerator MagnetRoutine()
    {
        coinCollector.SetActive(true);
        Debug.Log("Enabled");
        yield return new WaitForSeconds(timeToWait);
        coinCollector.SetActive(false);
        Debug.Log("Disabled");

    }

}
