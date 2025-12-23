using UnityEngine;

public class VehicleSelector : MonoBehaviour
{
    [SerializeField] GameObject bikePrefab;
    [SerializeField] GameObject CarPrefab;

    private void Awake()
    {
        string selected = PlayerPrefs.GetString("SelectedVehicle");
        if(selected == "Bike")
        {
            Instantiate(bikePrefab, transform.position, Quaternion.identity, transform);
        }
        else if(selected == "Car")
        {
            Instantiate(CarPrefab, transform.position, Quaternion.identity, transform);

        }
    }
}
