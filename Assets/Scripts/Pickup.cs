using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        OnPickup();
        Destroy(this.gameObject);
    }

    protected abstract void OnPickup();


}
