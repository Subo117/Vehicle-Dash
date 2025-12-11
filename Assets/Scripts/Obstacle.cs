using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int obstacleSpeed = 5;
    void Update()
    {
        transform.Translate(Vector3.back * obstacleSpeed * Time.deltaTime);
    }
}
