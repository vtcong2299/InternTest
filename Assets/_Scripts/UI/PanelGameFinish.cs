using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGameFinish : MonoBehaviour
{
    [SerializeField] Button retryButton;
    [SerializeField] Button skipButton;
    [SerializeField] Text txtLevel;
    [SerializeField] Text txtIQ;

    private void Start()
    {
        retryButton.onClick.AddListener(ClickRetryButton);
        skipButton.onClick.AddListener(ClickSkipsButton);
    }
    public void ChangeTextFinish()
    {
        ChangeLevelText(GameManager.Instance.idCurMap);
        txtIQ.gameObject.transform.localScale = 0.6f * Vector3.one;
        txtIQ.gameObject.transform.DOScale(Vector3.one, 0.3f)
            .SetEase(Ease.InOutBack)
            .SetUpdate(UpdateType.Normal, true)
            .OnComplete(() =>
            {
                ChangeTextIQ(GameManager.Instance.iq);
            });
    }
    void ClickRetryButton()
    {
        UIManager.Instance.OnDisablePanelGameFinish();
        GameManager.Instance.ClickRetry();
    }
    void ClickSkipsButton()
    {
        GameManager.Instance.NextLevelByAds();
    }
    public void ChangeTextIQ(int iq)
    {
        txtIQ.text = iq + " IQ";
    }
    public void ChangeLevelText(int level)
    {
        txtLevel.text = "Level " + level;
    }
}
