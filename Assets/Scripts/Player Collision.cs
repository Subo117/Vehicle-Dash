using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    bool isCrashed = false;
    PlayerControl playerControl;

    private void Start()
    {
        playerControl = GetComponentInParent<PlayerControl>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            isCrashed = true;
            playerControl.isMovable = false;
        }
    }

    public bool IsCrashed()
    {
        return isCrashed;
    }
}
