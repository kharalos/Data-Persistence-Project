using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavedDataHandler : MonoBehaviour
{
    public static SavedDataHandler Instance;

    public int highScore;

    public string playerName;
    public string highScoreName;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        LoadHighScore();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string playerName;
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.playerName = playerName;
        highScoreName = playerName;

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

            highScore = data.highScore;
            highScoreName = data.playerName;
        }
    }
}
