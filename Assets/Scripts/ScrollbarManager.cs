using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollbarManager : MonoBehaviour
{
    string selectedVehicle;


    private void Awake()
    {
        selectedVehicle = "None";
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);
    }

    public void OnBike()
    {
        Debug.Log("Bike");
        selectedVehicle = "Bike";
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void OnCar()
    {
        Debug.Log("Car");
        selectedVehicle = "Car";
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
    public void OnJeep()
    {
        Debug.Log("Jeep");
        selectedVehicle = "Jeep";
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void OnMiniVan()
    {
        Debug.Log("Mini Van");
        selectedVehicle = "Mini Van";
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnTruck()
    {
        Debug.Log("Truck");
        selectedVehicle = "Truck";
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnTempo()
    {
        Debug.Log("Tempo");
        selectedVehicle = "Tempo";
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
