using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;

    [SerializeField] float coinSpawnChance = 0.6f;
    [SerializeField] float carSpawnChance = 0.8f;
    [SerializeField] float boostSpawnChance = 0.5f;


    [SerializeField] List<GameObject> obstacles;
    [SerializeField] List<GameObject> boosts;

    List<int> availableLanes = new List<int> { 0, 1, 2 };
    float[] lanes = { -15f, 0f, 15f };


    private void Start()
    {
        SpawnCar();
        SpawnCoin();
        SpawnBoost();
    }
    void SpawnCar()
    {
        if (Random.value > carSpawnChance) return;
        if (availableLanes.Count == 0) return;
        int selectedLane = SelectLane();

        GameObject selectedObstacle = obstacles[Random.Range(0, obstacles.Count)];
        Vector3 fencePos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(selectedObstacle, fencePos, Quaternion.identity, this.transform);


    }

    void SpawnCoin()
    {
        if (Random.value > coinSpawnChance) return;
        if (availableLanes.Count == 0) return;
        int selectedLane = SelectLane();

        GameObject selectedObstacle = obstacles[Random.Range(0, obstacles.Count)];
        Vector3 coinPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(coinPrefab, coinPos, Quaternion.identity, this.transform);


    }

    void SpawnBoost()
    {
        if (Random.value > boostSpawnChance) return;
        if (availableLanes.Count == 0) return;
        int selectedLane = SelectLane();

        GameObject selectedBoost = boosts[Random.Range(0, boosts.Count)];
        Vector3 boostPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(selectedBoost, boostPos, Quaternion.identity, this.transform);
    }

    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }
}