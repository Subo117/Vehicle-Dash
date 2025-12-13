using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();

    List<int> availableLanes = new List<int> { 0, 1, 2 };
    float[] lanes = { -15f, 0f, 15f };


    private void Start()
    {
        SpawnFence();
    }
    void SpawnFence()
    {
        if (availableLanes.Count == 0) return;
        int selectedLane = SelectLane();

        GameObject selectedObstacle = obstacles[Random.Range(0, obstacles.Count)];
        Vector3 fencePos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(selectedObstacle, fencePos, Quaternion.identity, this.transform);
        

    }

    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }
}
