using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    long coins = 0;

    private void Start()
    {
        coins = GameSaver.Instance.Coins;
    }
    public void IncreaseScore(int scoreToIncrease)
    {
        coins += scoreToIncrease;
        Debug.Log(coins);
        GameSaver.Instance.SaveCoins(coins);
    }

}
