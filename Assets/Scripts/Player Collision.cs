using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] float timeToWait = 10f;

    PlayerControl playerControl;
    ScoreManager scoreManager;
    CoinMove coinMove;


    public bool isCrashed = false;
    bool isShieldActive = false;

    Coroutine shieldCoroutine;
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
        if (collision.gameObject.CompareTag("Shield"))
        {
            Debug.Log("Shield collider");
            if(shieldCoroutine != null)
            {
                StopCoroutine(shieldCoroutine);
            }
            shieldCoroutine =  StartCoroutine(ShieldCoroutine(collision));
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            scoreManager.IncreaseScore();
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

}
