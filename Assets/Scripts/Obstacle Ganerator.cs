using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ObstacleGanerator : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] Transform obstacleParent;

    GameSpeedManager gameSpeedManager;

    float oneObstacleInThisSec;

    float[] Lanes = {-15f, 0f, 15f};

    float currTime = 0f;

    private void Awake()
    {
        gameSpeedManager = FindAnyObjectByType<GameSpeedManager>();
    }

    private void Start()
    {
    }
    private void Update()
    {
        HandleObstacleSpawning();
    }

    void HandleObstacleSpawning()
    {
        oneObstacleInThisSec = gameSpeedManager.obstacleSpawnRate;
        currTime += Time.deltaTime;
        if(currTime > oneObstacleInThisSec)
        {
            SpawnObstacle();
            currTime = 0f;
        }

    }

    void SpawnObstacle()
    {
        GameObject selectedObstacle = obstacles[Random.Range(0, obstacles.Count)];
        float selectedLane = Lanes[Random.Range(0, Lanes.Length)];

        Instantiate(selectedObstacle, new Vector3(selectedLane , transform.position.y , transform.position.z), Quaternion.identity, obstacleParent);
    }
}
