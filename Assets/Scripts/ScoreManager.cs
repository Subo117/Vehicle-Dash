using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    long coins = 0;
    GameSaver gameSaver;

    private void Start()
    {
        gameSaver = FindAnyObjectByType<GameSaver>();
        coins = gameSaver.GetCoins();
    }
    public void IncreaseScore(int scoreToIncrease)
    {
        coins += scoreToIncrease;
        Debug.Log(coins);
        gameSaver.SaveCoins(coins);
    }

    private void OnApplicationQuit()
    {
        gameSaver.SaveCoins(coins);
    }
}
