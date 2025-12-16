using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] float timeToWait = 10f;
    public bool isCrashed = false;
    bool isShieldActive = false;
    PlayerControl playerControl;

    Coroutine shieldCoroutine;
    private void Start()
    {
        playerControl = GetComponentInParent<PlayerControl>();
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
    }

    IEnumerator ShieldCoroutine(Collision collision)
    {
        isShieldActive = true;
        Destroy(collision.gameObject);
        yield return new WaitForSeconds(timeToWait);
        isShieldActive = false;
    }

}
