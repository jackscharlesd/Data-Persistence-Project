using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public int GameScore;
    public string PlayerName;
    public SavedData GameData;


    private void Awake()
    {
        Debug.Log("in DataManager.Awake");
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGameData();
    }

    public void StoreGameData()
    {
        Debug.Log("in DataManager.StoreGameData");
        string json = JsonUtility.ToJson(GameData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("GameData saved to " + Application.persistentDataPath);
    }
    public void LoadGameData()
    {
        Debug.Log("in DataManager.LoadGameData");
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            Debug.Log("file exists");
            string json = File.ReadAllText(path);
            GameData = JsonUtility.FromJson<SavedData>(json);
        }
        else
        {
            GameData = new SavedData();
        }
    }
}
[System.Serializable]
public class SavedData
{
    public int HighScore;
    public string PlayerName;
}

