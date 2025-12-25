using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    public static GameSaver Instance;
    string path;
    PlayerData data;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        path = Application.persistentDataPath + "/PlayerData.json";

        EnsurePath();
        LoadData();


    }

    public long Coins { get; private set; }
    void EnsurePath()
    {
        if (string.IsNullOrEmpty(path))
            path = Application.persistentDataPath + "/PlayerData.json";
    }

    public void Save()
    {
        EnsurePath();
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }
    
    public void SaveCoins(long coins)
    {
        EnsurePath();
        Coins = coins;
        
        data.coins = coins;
        Save();
    }

    public void LoadData()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            data = new PlayerData();
            data.coins = 0;
            data.unlockedvehicles = new List<string>() { "Bike" };
            Save();
        }

        if (data.unlockedvehicles == null)
            data.unlockedvehicles = new List<string>();

        Coins = data.coins;
    }

    public void UnlockVehicle(string vehicle)
    {
        if (!data.unlockedvehicles.Contains(vehicle))
        {
            data.unlockedvehicles.Add(vehicle);
            Save();
        }
    }

    public bool IsVehicleUnlocked(string vehicle)
    {
        return data.unlockedvehicles.Contains(vehicle);
    }

    public List<string> GetUnlockedVehicle()
    {
        return data.unlockedvehicles;
    }


}
