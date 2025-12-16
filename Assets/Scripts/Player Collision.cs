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

    Coroutine shieldCoroutine;
    Coroutine magnetCoroutine;
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
            scoreManager.IncreaseScore();
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
    }

    IEnumerator ShieldCoroutine(Collision collision)
    {
        isShieldActive = true;
        Destroy(collision.gameObject);
        yield return new WaitForSeconds(timeToWait);
        isShieldActive = false;
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
