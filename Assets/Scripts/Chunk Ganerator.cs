using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ChunkGanerator : MonoBehaviour
{
    [SerializeField] GameObject roadPrefab;
    [SerializeField] GameObject tempRoadPrefab;

    [SerializeField] Transform chunkParent;

    [SerializeField] int noOfRoads = 15;
    [SerializeField] int chunkDist = 20;
    [SerializeField] float minChunkRangeOfZ = -100f;
    [SerializeField] float chunkMoveSpeed = 15f;


    List<GameObject> chunks = new List<GameObject>();
    List<GameObject> tempChunks = new List<GameObject>();


    GameSpeedManager gameSpeedManager;

    float[] lanes = { -15f, 0f, 15f };

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
        
    }

    void GenerateChunk()
    {
        for(int i = 0; i < 4; i++)
        {
            GameObject chunk =  Instantiate(tempRoadPrefab, new Vector3(transform.position.x, transform.position.y, i * chunkDist), Quaternion.identity, chunkParent);
            tempChunks.Add(chunk);
        }
        for (int road = 0; road < noOfRoads; road++)
        {
            Vector3 chunkSpawnPos = transform.position + new Vector3(0, 0, road * chunkDist + 4 * chunkDist) ;
            GameObject chunkGO =  Instantiate(roadPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);
            chunks.Add(chunkGO);

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

        for (int i = 0; i < chunks.Count; i++)
        {

            GameObject chunk = chunks[i];
            chunk.transform.Translate(Vector3.back * chunkMoveSpeed * Time.deltaTime);
            
            DestroyChunk(chunk);
        
        }
    }


    

    void DestroyChunk(GameObject firstChunk)
    {
        if (firstChunk.transform.position.z < minChunkRangeOfZ)
        {
            chunks.Remove(firstChunk);
            Destroy(firstChunk);
            SpawnNewChunk();
        }
        
    }

    void SpawnNewChunk()
    {
        Vector3 chunkSpawnPos = chunks[chunks.Count - 1].transform.position + new Vector3(0, 0, chunkDist);
        GameObject newChunk = Instantiate(roadPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);
        chunks.Add(newChunk);

    }




}
