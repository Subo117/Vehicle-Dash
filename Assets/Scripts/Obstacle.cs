using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float minChunkRangeOfZ = -50f;

    GameSpeedManager gameSpeedManager;


    [SerializeField]float obstacleSpeed;

    private void Awake()
    {
        gameSpeedManager = FindAnyObjectByType<GameSpeedManager>();
    }

    private void Start()
    {
        obstacleSpeed = gameSpeedManager.currentSpeed;
    }


    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        transform.Translate(Vector3.back * obstacleSpeed * Time.deltaTime);
        if(transform.position.z < minChunkRangeOfZ)
        {
            Destroy(this.gameObject);
        }

    }
}
