using System.IO;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    string path;

    private void Awake()
    {
        path = Application.persistentDataPath + "/PlayerData.json";
    }

    public void SaveCoins(long coins)
    {
        EnsurePath();
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
        return data.coins;
    }

    void EnsurePath()
    {
        if (string.IsNullOrEmpty(path))
            path = Application.persistentDataPath + "/PlayerData.json";
    }

}
