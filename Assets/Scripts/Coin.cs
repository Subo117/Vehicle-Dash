using UnityEngine;

public class Coin : Pickup
{
    ScoreManager scoreManager;
    private void Awake()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }
    protected override void OnPickup()
    {
        scoreManager.IncreaseScore();
    }
}
