using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGameStart : MonoBehaviour
{
    [SerializeField] Button playButton;

    private void Start()
    {
        playButton.onClick.AddListener(ClickPlayButton);
    }
    public void ClickPlayButton()
    {
        UIManager.Instance.OnDisablePanelGameStart();
        UIManager.Instance.OnEnablePanelGameLevel();
    }
}
