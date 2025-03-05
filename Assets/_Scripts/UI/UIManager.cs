using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] GameObject panelGamePlay;
    [SerializeField] GameObject panelGameFinish;
    [SerializeField] GameObject panelGameStart;
    [SerializeField] GameObject panelGameLevel;

    [SerializeField] CanvasGroup gamePlayCG;
    [SerializeField] CanvasGroup gameFinishCG;
    [SerializeField] CanvasGroup gameStartCG;
    [SerializeField] CanvasGroup gameLevelCG;

    public void OnEnablePanelGamePlay()
    {
        AnimFadeIn(panelGamePlay, gamePlayCG);
    }
    public void OnDisablePanelGamePlay()
    {
        AnimFadeOut(panelGamePlay, gamePlayCG);
    }
    public void OnEnablePanelGameFinish()
    {
        AnimPlayerUI.Instance.AnimDead(true);
        AnimFadeIn(panelGameFinish, gameFinishCG);
    }
    public void OnDisablePanelGameFinish()
    {
        AnimFadeOut(panelGameFinish, gameFinishCG);
    }
    public void OnEnablePanelGameStart()
    {
        AnimPlayerUI.Instance.AnimDead(false);
        AnimFadeIn(panelGameStart, gameStartCG);
    }
    public void OnDisablePanelGameStart()
    {
        AnimFadeOut(panelGameStart, gameStartCG);
    }
    public void OnEnablePanelGameLevel()
    {
        AnimFadeIn(panelGameLevel, gameLevelCG);
    }
    public void OnDisablePanelGameLevel()
    {
        AnimFadeOut(panelGameLevel, gameLevelCG);
    }


    void AnimFadeIn(GameObject panel, CanvasGroup panelCG)
    {
        panel.SetActive(true);
        panelCG.alpha = 0;
        panelCG.DOFade(1, 0.3f)
            .SetUpdate(UpdateType.Normal, true);
    }
    void AnimFadeOut(GameObject panel, CanvasGroup panelCG)
    {
        panelCG.DOFade(0, 0.3f)
            .OnComplete(() =>
            {
                panel.SetActive(false);
                AnimPlayerUI.Instance.AnimDead(false);
            });
    }
}
