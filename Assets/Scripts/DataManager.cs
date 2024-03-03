using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string currentPlayerName;
    public string highscorePlayerName;
    public int highscore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighscoreData();
    }

    [Serializable]
    class SaveData
    {
        public string playerName;
        public int highscore;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadHighscoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(Application.persistentDataPath + "/savefile.json");
            SaveData data = JsonUtility.FromJson<SaveData>(jsonString);

            highscorePlayerName = data.playerName;
            highscore = data.highscore;
        }
        else
        {
            highscore = 0;
            highscorePlayerName = "Nobody";
        }
    }

    public void SaveHighscoreData(int score)
    {
        if (score > highscore)
        {
            highscore = score;
            highscorePlayerName = currentPlayerName;

            SaveData data = new SaveData();
            data.highscore = score;
            data.playerName = currentPlayerName;

            string jsonString = JsonUtility.ToJson(data);
            string path = Application.persistentDataPath + "/savefile.json";
            File.WriteAllText(path, jsonString);
        }
    }
}
