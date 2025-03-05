using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGameFinish : MonoBehaviour
{
    [SerializeField] Button retryButton;
    [SerializeField] Text txtLevel;
    [SerializeField] Text txtIQ;

    private void Start()
    {
        retryButton.onClick.AddListener(ClickRetryButton);
    }

    void ClickRetryButton()
    {
        UIManager.Instance.OnDisablePanelGameFinish();
        PlayerCtrl.Instance.ResetPlayer();
    }
    public void ChangeTextIQ(int iq)
    {
        txtIQ.text = "-" + iq + " IQ";
    }
    public void ChangeLevelText(int level)
    {
        txtLevel.text = "Level " + level;
    }
}
