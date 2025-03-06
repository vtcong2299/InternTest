using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] GameObject panelGamePlay;
    [SerializeField] GameObject panelGameFinish;
    [SerializeField] GameObject panelGameStart;
    [SerializeField] GameObject panelGameLevel;

    [SerializeField] GameObject panelLoading1;
    [SerializeField] GameObject panelLoading2;

    [SerializeField] CanvasGroup gamePlayCG;
    [SerializeField] CanvasGroup gameFinishCG;
    [SerializeField] CanvasGroup gameStartCG;
    [SerializeField] CanvasGroup gameLevelCG;

    public PanelGameLevel gameLevel;
    public PanelGameFinish gameFinish;

    private void Start()
    {
        Init();
    }
    void Init()
    {
        panelGamePlay.SetActive(false);
        panelGameFinish.SetActive(false);
        panelGameStart.SetActive(true);
        panelGameLevel.SetActive(false);
        panelLoading1.SetActive(false);
        panelLoading2.SetActive(false);
    }
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
        gameFinish.ChangeTextFinish();
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

    public void AnimLoading1()
    {
        panelLoading1.SetActive(true);
        DOVirtual.DelayedCall(1f, () =>
        {
            panelLoading1.SetActive(false);
        });
    }
    public void AnimLoading2()
    {
        panelLoading2.SetActive(true);
        DOVirtual.DelayedCall(0.5f, () =>
        {
            panelLoading2.SetActive(false);
        });
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
    public void SelectLevel()
    {
        AnimLoading2();
        gameFinish.ChangeTextFinish();
        OnDisablePanelGameLevel();
        OnEnablePanelGamePlay();
    }
    public void ChangeImageButtonLevel(int index, bool on)
    {
        gameLevel.ChangeImageButton(index, on);
    }
}
