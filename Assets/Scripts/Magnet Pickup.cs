using UnityEngine;

public class MagnetPickup : Pickup
{
    protected override void OnPickup()
    {
        Debug.Log("Magnet");

    }
}
