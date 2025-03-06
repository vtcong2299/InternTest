using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    int curID;
    [SerializeField] ConfigMap[] configMap;
    [SerializeField] GameObject currentMap;
    [SerializeField] GameObject waitMap;

    [SerializeField] GameObject[] lockMap;

    public void SelectLevel(int idMap)
    {
        foreach (ConfigMap map in configMap)
        {
            if (map._id == idMap)
            {
                curID = map._id;
                waitMap = Resources.Load<GameObject>(map._name);
                break;
            }
            else
            {
                waitMap = null;
            }
        }
        if (currentMap != null)
        {
            Destroy(currentMap);
            Resources.UnloadUnusedAssets();
        }
        if (waitMap == null)
        {
            return;
        }
        currentMap = Instantiate(waitMap, transform.position, transform.rotation);
    }
    public void NextLevel()
    {
        curID++;
        if (curID > configMap.Length)
        {
            curID = 1;
        }
        GameManager.Instance.SelectLevel(curID);
    }
    public void CheckUnLockMap()
    {
        foreach (ConfigMap map in configMap)
        {
            if (map._id <= DataManager.Instance.gameData.idMapCompeleteMax + 1)
            {
                lockMap[map._id - 1].SetActive(false);
                UIManager.Instance.ChangeImageButtonLevel(map._id - 1, true);
            }
            else
            {
                lockMap[map._id - 1].SetActive(true); 
                UIManager.Instance.ChangeImageButtonLevel(map._id - 1, false);
            }
        }
    }
    public void UnLockMapOnComplete(int idCurMap)
    {
        foreach (ConfigMap map in configMap)
        {
            if (map._id == idCurMap)
            {
                if (DataManager.Instance.gameData.idMapCompeleteMax < map._id)
                {
                    DataManager.Instance.gameData.idMapCompeleteMax = map._id - 1;
                }
                CheckUnLockMap();
                DataManager.Instance.SaveData();
                break;
            }
        }

    }
}
