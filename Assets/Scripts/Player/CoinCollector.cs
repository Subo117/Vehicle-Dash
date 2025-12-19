using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            CoinMove coinmove = collision.gameObject.GetComponent<CoinMove>();
            coinmove.MoveCoin(true);
        }
    }
}
