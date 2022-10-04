using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string highScorePlayer;
    public string playerName;
    public int points;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    [Serializable]
    class SaveData
    {
        public string highScorePlayer;
        public int points;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScorePlayer = highScorePlayer;
        data.points = points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayer = data.highScorePlayer;
            points = data.points;
        }
    }

}
