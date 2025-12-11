using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ChunkGanerator : MonoBehaviour
{
    [SerializeField] GameObject RoadPrefab;
    [SerializeField] Transform chunkParent;
    [SerializeField] int noOfRoads = 15;
    [SerializeField] int chunkDist = 40;
    [SerializeField] float chunkMoveSpeed = 10f;
    [SerializeField] float minChunkRangeOfZ = -50;

    List<GameObject> chunks = new List<GameObject>();

    private void Start()
    {
        GenerateChunk();
    }

    private void Update()
    {
        foreach(GameObject chunk in chunks)
        {
            chunk.transform.Translate(Vector3.back * chunkMoveSpeed * Time.deltaTime);
            
        }
        ManageChunk();

    }

    void GenerateChunk()
    {
        for(int road = 0; road < noOfRoads; road++)
        {
            GameObject chunk =  Instantiate(RoadPrefab, new Vector3(transform.position.x, transform.position.y, road * chunkDist), Quaternion.identity, chunkParent);
            chunks.Add(chunk);
        }
    }

    void ManageChunk()
    {
        if(chunks.Count > 0)
        {
            GameObject firstChunk = chunks[0];
            if(firstChunk.transform.position.z < minChunkRangeOfZ)
            {
                DestroyChunk(firstChunk);

                
            }
        }
    }

    void DestroyChunk(GameObject firstChunk)
    {
        chunks.Remove(firstChunk);
        Destroy(firstChunk);

        SpawnNewChunk();

    }

    void SpawnNewChunk()
    {
        float newZ = chunks[chunks.Count - 1].transform.position.z + chunkDist;
        Vector3 spawnPos = new Vector3(0, 0, newZ);
        GameObject newChunk = Instantiate(RoadPrefab, spawnPos, Quaternion.identity, chunkParent);
        chunks.Add(newChunk);
    }

    



}
