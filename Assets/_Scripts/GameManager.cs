using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject player;
    public int idCurMap = 0;
    public int iq = 0;
    public bool playOnMobile;
    private void Start()
    {
        SetLevel(0);
    }
    private void OnEnable()
    {
        DataManager.Instance.SetFPS();
    }
    public void CheckUnlockMap()
    {
        LevelManager.Instance.UnLockMapOnComplete(idCurMap);
    }
    public void SetLevel(int level)
    {
        player.SetActive(false);
        LevelManager.Instance.SelectLevel(level);
    }

    public void SelectLevel(int level)
    {
        idCurMap = level;
        UIManager.Instance.SelectLevel();
        SetLevel(level);
        player.SetActive(true);
        PlayerCtrl.Instance.ResetPlayer();
    }
    public void NextLevel()
    {
        LevelManager.Instance.NextLevel();
        CheckUnlockMap();
        iq = 0;
    }
    public void UnLoadLevel()
    {
        SetLevel(0);
    }
    public void NextLevelByAds()
    {
        UIManager.Instance.AnimLoading1();
        UIManager.Instance.OnDisablePanelGameFinish();
        Invoke("NextLevel",1f);
    }
    public void ClickRetry()
    {
        PlayerCtrl.Instance.ResetPlayer();
        PlayerCtrl.Instance.ResetAnimPlayer();
    }
    public void ShowPanelFinish()
    {
        UIManager.Instance.AnimLoading1();
        DOVirtual.DelayedCall(1f, () =>
        {
            UIManager.Instance.AnimLoading2();
            UIManager.Instance.OnEnablePanelGameFinish();
        });

    }
}
