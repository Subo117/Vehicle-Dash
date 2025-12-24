using System.IO;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    public static GameSaver Instance;
    string path;

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

        GetCoins();

    }

    public long Coins { get; private set; }
    
    public void SaveCoins(long coins)
    {
        EnsurePath();
        Coins = coins;
        PlayerData data = new PlayerData();
        data.coins = coins;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public long GetCoins()
    {
        if(!File.Exists(path)) return 0;

        string json = File.ReadAllText(path);
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Coins = data.coins;
        return Coins;
    }

    void EnsurePath()
    {
        if (string.IsNullOrEmpty(path))
            path = Application.persistentDataPath + "/PlayerData.json";
    }

}
