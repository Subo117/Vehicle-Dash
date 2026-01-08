using UnityEngine;

public class VehicleSelector : MonoBehaviour
{
    [SerializeField] GameObject PickupPrefab;
    [SerializeField] GameObject carPrefab;
    [SerializeField] GameObject omniPrefab;
    [SerializeField] GameObject jeepPrefab;
    [SerializeField] GameObject buggyPrefab;
    [SerializeField] GameObject policePrefab;
    [SerializeField] GameObject vintagePrefab;
    [SerializeField] GameObject cartoonPrefab;
    [SerializeField] GameObject BugattiPrefab;

    private void Awake()
    {
        string selected = PlayerPrefs.GetString("SelectedVehicle");
        if(selected == "Pickup")
        {
            Instantiate(PickupPrefab, transform.position, Quaternion.identity, transform);
        }
        else if(selected == "Car")
        {
            Instantiate(carPrefab, transform.position, Quaternion.identity, transform);

        }
        else if(selected == "Omni")
        {
            Instantiate(omniPrefab, transform.position, Quaternion.identity, transform);

        }
        else if (selected == "Jeep")
        {
            Instantiate(jeepPrefab, transform.position, Quaternion.identity, transform);

        }
        else if (selected == "Buggy")
        {
            Instantiate(buggyPrefab, transform.position, Quaternion.identity, transform);

        }
        else if (selected == "Police")
        {
            Instantiate(policePrefab, transform.position, Quaternion.identity, transform);

        }
        else if (selected == "Vintage")
        {
            Instantiate(vintagePrefab, transform.position, Quaternion.identity, transform);

        }
        else if (selected == "Cartoon")
        {
            Instantiate(cartoonPrefab, transform.position, Quaternion.identity, transform);

        }
        else if (selected == "Bugatti")
        {
            Instantiate(BugattiPrefab, transform.position, Quaternion.identity, transform);

        }
    }
}
