using UnityEngine;

public class Coin : MonoBehaviour
{
    ScoreManager scoreManager;
    CoinMove coinMove;
    private void Awake()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
        coinMove = GetComponent<CoinMove>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CoinCollector"))
        {
            coinMove.MoveCoin(true);
        }

        if (other.CompareTag("Player"))
        {
            scoreManager.IncreaseScore();
            Destroy(gameObject);
        }


    }
}
