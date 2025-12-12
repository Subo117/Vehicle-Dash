using UnityEngine;

public class GameSpeedManager : MonoBehaviour
{
    [SerializeField] float maxSpeed = 200f;
    [SerializeField] float secondsForSpeedBoost = 5f;
    [SerializeField] public float obstacleSpawnRate = 2f;

    public float baseSpeed = 15f;
    public float currentSpeed = 15f;
    float timer = 0f;


    private void Update()
    {
        HandleLinearSpeedIncrement();
    }

    void HandleLinearSpeedIncrement()
    {
        if (currentSpeed > maxSpeed) return;
        timer += Time.deltaTime;
        if (timer > secondsForSpeedBoost)
        {
            baseSpeed++;
            currentSpeed = baseSpeed;
            Debug.Log(currentSpeed);
            obstacleSpawnRate -= Time.deltaTime;
            timer = 0;
        }

    }
}
