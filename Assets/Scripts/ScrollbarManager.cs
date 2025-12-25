using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollbarManager : MonoBehaviour
{
    [SerializeField] List<GameObject> dullScreenList;
    [SerializeField] GameObject buyScreen;
    string selectedVehicle;

    Dictionary<string, int> vehicleCosts = new Dictionary<string, int>()
    {
        {"Car",1000 },
        {"Jeep", 5000 },
        {"Mini Van", 10000 },
        {"Truck", 20000 },
        {"Tempo", 25000 }
    };

    private void Start()
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
        TrySelectVehicle("Car");

    }
    public void OnJeep()
    {
        Debug.Log("Jeep");
        TrySelectVehicle("Jeep");

    }
    public void OnMiniVan()
    {
        Debug.Log("Mini Van");
        TrySelectVehicle("Mini Van");

    }
    public void OnTruck()
    {
        Debug.Log("Truck");
        TrySelectVehicle("Truck");

    }
    public void OnTempo()
    {
        Debug.Log("Tempo");
        TrySelectVehicle("Tempo");

    }

    void TrySelectVehicle(string vehicle)
    {
        if (GameSaver.Instance.IsVehicleUnlocked(vehicle))
        {
            PlayerPrefs.SetString("SelectedVehicle", vehicle);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            ShowBuyScreen(vehicleCosts[vehicle]);
        }
    }
    void ShowBuyScreen(int vehicleCost)
    {
        buyScreen.SetActive(true);
        TMP_Text buyText = buyScreen.GetComponentInChildren<TMP_Text>();

        

        buyText.text = "Want to but for " + vehicleCost.ToString() + " ?";

    }



}

