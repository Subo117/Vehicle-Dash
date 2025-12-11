using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ObstacleGanerator : MonoBehaviour
{
    [SerializeField] float timer = 2;
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] Transform obstacleParent;
    

    float[] Lanes = {-15f, 0f, 15f};

    float currTime = 0f;


    private void Update()
    {
        currTime += Time.deltaTime;
        if(currTime > timer)
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
