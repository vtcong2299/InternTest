using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public int idMapCompeleteMax = 0;
    public int fps = 60;
    //public bool isPlayOnMobile;
}
public class DataGamePlay : MonoBehaviour
{
    private const string GameDataKey = "GameData";
    //private string dataPath;

    private void Start()
    {
        //dataPath = Path.Combine(Application.persistentDataPath, "playerData.json");
        LoadData(); 
    }

    public void SaveData(GameData data)
    {
        //Lưu bằng Playprefs
        string json = JsonUtility.ToJson(data); 
        PlayerPrefs.SetString(GameDataKey, json);
        PlayerPrefs.Save(); 

        // Lưu dữ liệu vào file hệ thống
        //File.WriteAllText(dataPath, json);
    }

    public GameData LoadData()
    {
        if (PlayerPrefs.HasKey(GameDataKey))
        {
            string json = PlayerPrefs.GetString(GameDataKey);
            GameData data = JsonUtility.FromJson<GameData>(json);
            return data;
        }
        //else if (File.Exists(dataPath))
        //{
        //    string json = File.ReadAllText(dataPath);
        //    GameData data = JsonUtility.FromJson<GameData>(json);
        //    return data;
        //}
        return new GameData(); 
    }

    public void ResetData()
    {
        if (PlayerPrefs.HasKey(GameDataKey))
        {
            PlayerPrefs.DeleteKey(GameDataKey);
        }

        //if (File.Exists(dataPath))
        //{
        //    File.Delete(dataPath);
        //}
    }
}
