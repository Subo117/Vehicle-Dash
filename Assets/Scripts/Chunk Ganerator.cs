using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ChunkGanerator : MonoBehaviour
{
    [SerializeField] GameObject RoadPrefab;

    [SerializeField] Transform obstacleSpawnPos;
    [SerializeField] Transform chunkParent;
    [SerializeField] Transform obstacleParent;

    [SerializeField] int noOfRoads = 15;
    [SerializeField] int chunkDist = 20;
    [SerializeField] float minChunkRangeOfZ = -100f;
    [SerializeField] float chunkMoveSpeed = 15f;

    [SerializeField] List<GameObject> obstacles = new List<GameObject>();

    List<GameObject> chunks = new List<GameObject>();
    List<GameObject> tempChunks = new List<GameObject>();
    List<GameObject> obstaclesCollection = new List<GameObject>();


    GameSpeedManager gameSpeedManager;

    float[] Lanes = { -15f, 0f, 15f };

    int initialRoadCnt = 0;

    private void Awake()
    {
        gameSpeedManager = FindAnyObjectByType<GameSpeedManager>();
    }
    private void Start()
    {
        GenerateChunk();

    }

    private void Update()
    {
        MoveTempChunk();
        MoveChunk();
        ManageChunk();
        
    }

    void GenerateChunk()
    {
        for(int i = 0; i < 4; i++)
        {
            GameObject chunk =  Instantiate(RoadPrefab, new Vector3(transform.position.x, transform.position.y, i * chunkDist), Quaternion.identity, chunkParent);
            tempChunks.Add(chunk);
        }
        for (int road = 0; road < noOfRoads; road++)
        {
            GameObject chunk =  Instantiate(RoadPrefab, new Vector3(transform.position.x, transform.position.y, road * chunkDist + 4 * chunkDist), Quaternion.identity, chunkParent);
            chunks.Add(chunk);

            GameObject selectedObstacle = obstacles[Random.Range(0, obstacles.Count)];
            float selectedLane = Lanes[Random.Range(0, Lanes.Length)];

            GameObject obstacle = Instantiate(selectedObstacle, new Vector3(selectedLane, transform.position.y, road * chunkDist + 4 * chunkDist), Quaternion.identity, obstacleParent);
            obstaclesCollection.Add(obstacle);

        }
    }
    void MoveTempChunk()
    {
        for (int i = tempChunks.Count - 1; i >= 0; i--)
        {
            GameObject chunk = tempChunks[i];
            chunk.transform.Translate(Vector3.back * chunkMoveSpeed * Time.deltaTime);

            if (chunk.transform.position.z < minChunkRangeOfZ)
            {
                tempChunks.RemoveAt(i);
                Destroy(chunk);
            }
        }
    }

    void MoveChunk()
    {
        chunkMoveSpeed = gameSpeedManager.currentSpeed;

        for (int i = 0; i < obstaclesCollection.Count; i++)
        {

            GameObject chunk = chunks[i];
            chunk.transform.Translate(Vector3.back * chunkMoveSpeed * Time.deltaTime);

            GameObject obstacle = obstaclesCollection[i];
            obstacle.transform.Translate(Vector3.back * chunkMoveSpeed * Time.deltaTime);
        }
    }


    void ManageChunk()
    {

        if (chunks.Count > 0 && obstaclesCollection.Count > 0)
        {
            GameObject firstChunk = chunks[0];
            GameObject firstObstacle = obstaclesCollection[0];

            if (firstChunk.transform.position.z < minChunkRangeOfZ)
            {
                DestroyChunk(firstChunk, firstObstacle);
            }
            
        }
    }

    void DestroyChunk(GameObject firstChunk, GameObject firstObstacle)
    {
        chunks.Remove(firstChunk);
        Destroy(firstChunk);
        if(firstObstacle.transform.position.z < minChunkRangeOfZ)
        {
            obstaclesCollection.Remove(firstObstacle);
            Destroy(firstObstacle);
        }
        SpawnNewChunk();
    }

    void SpawnNewChunk()
    {
        float newZ = chunks[chunks.Count - 1].transform.position.z + chunkDist;
        Vector3 chunkSpawnPos = new Vector3(0, 0, newZ);
        GameObject newChunk = Instantiate(RoadPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);
        chunks.Add(newChunk);

        GameObject selectedObstacle = obstacles[Random.Range(0, obstacles.Count)];
        float selectedLane = Lanes[Random.Range(0, Lanes.Length)];

        GameObject obstacle = Instantiate(selectedObstacle, new Vector3(selectedLane, chunkSpawnPos.y, chunkSpawnPos.z), Quaternion.identity, obstacleParent);
        obstaclesCollection.Add(obstacle);

    }




}
