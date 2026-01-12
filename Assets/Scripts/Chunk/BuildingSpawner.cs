using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> Buildings;

    void Start()
    {
        SpawnBuilding();

    }



    void SpawnBuilding()
    {
        GameObject selectedBuildingLeft = Buildings[Random.Range(0, Buildings.Count)];
        GameObject selectedBuildingRight = Buildings[Random.Range(0, Buildings.Count)];
        Vector3 buildingLeftPos = new Vector3(-50, transform.position.y + 1, transform.position.z);
        Vector3 buildingRightPos = new Vector3(50, transform.position.y + 1, transform.position.z);
        Instantiate(selectedBuildingLeft, buildingLeftPos, Quaternion.identity, this.transform);
        Instantiate(selectedBuildingRight, buildingRightPos, Quaternion.Euler(0f, 180f, 0f), this.transform);
    }
}
