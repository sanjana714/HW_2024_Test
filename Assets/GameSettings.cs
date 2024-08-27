using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerData
{
    public float speed;
}

[System.Serializable]
public class PulpitData
{
    public float min_pulpit_destroy_time;
    public float max_pulpit_destroy_time;
    public float pulpit_spawn_time;
}

[System.Serializable]
public class GameData
{
    public float minPulpitDestroyTime;
    public float maxPulpitDestroyTime;
    public float pulpitSpawnTime;
    public PlayerData player_data;
    public PulpitData pulpit_data;
}

public class GameSettings : MonoBehaviour
{
    public GameData gameData;

    void Awake()
    {
        LoadGameSettings();
    }

    void LoadGameSettings()
    {
        string path = Path.Combine(Application.dataPath, "DoofusDiary.json");
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            gameData = JsonUtility.FromJson<GameData>(jsonData);
        }
        else
        {
            Debug.LogError("Cannot find game settings file!");
        }
    }
}