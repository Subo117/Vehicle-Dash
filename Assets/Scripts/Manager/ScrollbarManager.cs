using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrollbarManager : MonoBehaviour
{
    [SerializeField] List<GameObject> dullScreenList;
    [SerializeField] GameObject buyScreen;
    [SerializeField] GameObject purchaseSuccessScreen;

    [Header("Score Text")]
    [SerializeField] TMP_Text mainScoreText;
    [SerializeField] TMP_Text startScoreText;


    string selectedVehicle;

    List<string> vehicles = new List<string>() { "Car", "Omni", "Jeep", "Buggy", "Police", "Vintage", "Cartoon", "Bugatti"};
    
    Dictionary<string, int> vehicleCosts = new Dictionary<string, int>()
    {
        {"Car",1000 },
        {"Omni", 3000 },
        {"Jeep", 5000 },
        {"Buggy", 10000 },
        {"Police", 15000 },
        {"Vintage", 20000 },
        {"Cartoon", 25000 },
        {"Bugatti", 30000 }
    };
    

    private void Start()
    {
        selectedVehicle = "None";
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);
        
        foreach(string item in vehicles)
        {
            if (GameSaver.Instance.IsVehicleUnlocked(item))
            {
                dullScreenList[vehicles.IndexOf(item)].SetActive(false);
            }
        }
        mainScoreText.text = GameSaver.Instance.Coins.ToString();
        startScoreText.text = GameSaver.Instance.Coins.ToString();
    }

    public void OnPickup()
    {
        Debug.Log("Pickup");
        selectedVehicle = "Pickup";

        
        PlayerPrefs.SetString("SelectedVehicle", selectedVehicle);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        

    }
    public void OnCar()
    {
        Debug.Log("Car");
        TrySelectVehicle(vehicles[0]);

    }
    public void OnOmni()
    {
        Debug.Log("Omni");
        TrySelectVehicle(vehicles[1]);

    }
    public void OnJeep()
    {
        Debug.Log("Jeep");
        TrySelectVehicle(vehicles[2]);

    }
    public void OnBuggy()
    {
        Debug.Log("Buggy");
        TrySelectVehicle(vehicles[3]);

    }
    public void OnPolice()
    {
        Debug.Log("Police");
        TrySelectVehicle(vehicles[4]);

    }
    public void OnVintage()
    {
        Debug.Log("Vintage");
        TrySelectVehicle(vehicles[5]);

    }
    public void OnCartoon()
    {
        Debug.Log("Cartoon");
        TrySelectVehicle(vehicles[6]);

    }
    public void OnBugatti()
    {
        Debug.Log("Bugatti");
        TrySelectVehicle(vehicles[7]);

    }

    void TrySelectVehicle(string vehicle)
    {
        selectedVehicle = vehicle;
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

        

        buyText.text = "Want to buy " + selectedVehicle + " for " + vehicleCost.ToString() + " ?";

    }

    public void OnBuyClick()
    {
        TMP_Text buyText = buyScreen.GetComponentInChildren<TMP_Text>();

        if (GameSaver.Instance.Coins >= vehicleCosts[selectedVehicle] )
        {
            buyText.text = "Purchased Successfully";
            GameSaver.Instance.SaveCoins(GameSaver.Instance.Coins - vehicleCosts[selectedVehicle]);
            GameSaver.Instance.UnlockVehicle(selectedVehicle);
            Debug.Log(selectedVehicle + " Unlocked");
            dullScreenList[vehicles.IndexOf(selectedVehicle)].SetActive(false);
            buyScreen.SetActive(false);
            purchaseSuccessScreen.SetActive(true);
            mainScoreText.text = GameSaver.Instance.Coins.ToString();
            startScoreText.text = GameSaver.Instance.Coins.ToString();

        }
        else
        {
            buyText.text = "Not Enough Money";
        }
    }



}

