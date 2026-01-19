using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    long coins = 0;
    [SerializeField] TMP_Text scoreText;

    private void Start()
    {
        coins = GameSaver.Instance.Coins;
        scoreText.text = GameSaver.Instance.Coins.ToString();
    }
    public void IncreaseScore(int scoreToIncrease)
    {
        coins += scoreToIncrease;
        scoreText.text = GameSaver.Instance.Coins.ToString();
        Debug.Log(coins);
        GameSaver.Instance.SaveCoins(coins);
    }

}
