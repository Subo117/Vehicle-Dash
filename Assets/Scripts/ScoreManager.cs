using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    long Score = 0;

    public void IncreaseScore(int scoreToIncrease)
    {
        Score += scoreToIncrease;
        Debug.Log(Score);
    }
}
