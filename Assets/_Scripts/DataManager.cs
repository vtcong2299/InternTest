using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DataManager : Singleton<DataManager>
{
    public DataGamePlay dataGamePlay;
    public GameData gameData;

    private void Start()
    {
        LoadData();
    }
    public void SaveData()
    {
        if (dataGamePlay != null)
        {
            dataGamePlay.SaveData(gameData);
        }
    }
    public void LoadData()
    {
        gameData = dataGamePlay.LoadData();
    }
    public void ResetData()
    {
        dataGamePlay.ResetData();
    }
    public void SetFPS()
    {
        Application.targetFrameRate = gameData.fps;
    }
}
