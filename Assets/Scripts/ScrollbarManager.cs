using UnityEngine;

public class ScrollbarManager : MonoBehaviour
{
    string selectedVehicle;

    private void Awake()
    {
        selectedVehicle = "None";
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);
    }
    public void OnButton1()
    {
        Debug.Log("Bike");
        selectedVehicle = "Bike";
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);
    }
    public void OnButton2()
    {
        Debug.Log("Car");
        selectedVehicle = "Car";
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);

    }
    public void OnButton3()
    {
        Debug.Log("3");

    }
    public void OnButton4()
    {
        Debug.Log("4");

    }
    public void OnButton5()
    {
        Debug.Log("5");

    }
    public void OnButton6()
    {
        Debug.Log("6");

    }
}
