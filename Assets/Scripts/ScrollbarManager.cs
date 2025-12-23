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
    public void OnButton1()
    {
        Debug.Log("Bike");
        selectedVehicle = "Bike";
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void OnButton2()
    {
        Debug.Log("Car");
        selectedVehicle = "Car";
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
    public void OnButton3()
    {
        Debug.Log("Jeep");
        selectedVehicle = "Jeep";
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void OnButton4()
    {
        Debug.Log("Mini Van");
        selectedVehicle = "Mini Van";
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnButton5()
    {
        Debug.Log("Truck");
        selectedVehicle = "Truck";
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnButton6()
    {
        Debug.Log("Tempo");
        selectedVehicle = "Tempo";
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
