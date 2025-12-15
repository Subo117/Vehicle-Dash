using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    long Score = 0;

    public void IncreaseScore()
    {
        Score++;
        //Debug.Log(Score);
    }
}
