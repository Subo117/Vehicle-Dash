using UnityEngine;

public class VehicleSelector : MonoBehaviour
{
    [SerializeField] GameObject bikePrefab;
    [SerializeField] GameObject carPrefab;
    [SerializeField] GameObject jeepPrefab;
    [SerializeField] GameObject miniVanPrefab;
    [SerializeField] GameObject truckPrefab;
    [SerializeField] GameObject tempoPrefab;

    private void Awake()
    {
        string selected = PlayerPrefs.GetString("SelectedVehicle");
        if(selected == "Bike")
        {
            Instantiate(bikePrefab, transform.position, Quaternion.identity, transform);
        }
        else if(selected == "Car")
        {
            Instantiate(carPrefab, transform.position, Quaternion.identity, transform);

        }
        else if (selected == "Jeep")
        {
            Instantiate(jeepPrefab, transform.position, Quaternion.identity, transform);

        }
        else if (selected == "Mini Van")
        {
            Instantiate(miniVanPrefab, transform.position, Quaternion.identity, transform);

        }
        else if (selected == "Truck")
        {
            Instantiate(truckPrefab, transform.position, Quaternion.identity, transform);

        }
        else if (selected == "Tempo")
        {
            Instantiate(tempoPrefab, transform.position, Quaternion.identity, transform);

        }
    }
}
