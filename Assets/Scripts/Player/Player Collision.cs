using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] float timeToWait = 10f;

    CoinCollector collector;
    PlayerControl playerControl;
    ScoreManager scoreManager;

    public bool isCrashed = false;
    public bool isShieldActive = false;
    public bool isNitroActive = false;
    public bool isMissileActive = false;
    bool isTwiceCoinActive = false;

    Coroutine shieldCoroutine;
    Coroutine magnetCoroutine;
    Coroutine twiceCoinCoroutine;

    private void Start()
    {
        playerControl = GetComponentInParent<PlayerControl>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
        collector = FindAnyObjectByType<CoinCollector>();
        collector.gameObject.SetActive(false);

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
            if (isShieldActive && isNitroActive) return;
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
            if (isShieldActive && isNitroActive) return;
            if (magnetCoroutine != null)
            {
                StopCoroutine(magnetCoroutine);
            }
            magnetCoroutine = StartCoroutine(MagnetRoutine());
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("TwiceCoin"))
        {
            if (isShieldActive && isNitroActive) return;
            if (twiceCoinCoroutine != null)
            {
                StopCoroutine (twiceCoinCoroutine);
            }
            twiceCoinCoroutine = StartCoroutine(TwiceCoinCoroutine(collision));
        }
        else if (collision.gameObject.CompareTag("Nitro"))
        {
            if (isShieldActive && isNitroActive) return;
            isNitroActive = true;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Missile"))
        {
            if (isShieldActive && isNitroActive) return;
            Debug.Log("Collided");
            isMissileActive = true;
            Destroy(collision.gameObject);
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
        collector.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeToWait);
        collector.gameObject.SetActive(false);

    }

}
