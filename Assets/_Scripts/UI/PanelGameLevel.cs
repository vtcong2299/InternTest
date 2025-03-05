using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGameLevel : MonoBehaviour
{
    [SerializeField] Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(ClickBackButton);
    }
    public void ClickBackButton()
    {
        UIManager.Instance.OnDisablePanelGameLevel();
        UIManager.Instance.OnEnablePanelGameStart();
    }
}
