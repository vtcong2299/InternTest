using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGamePlay : MonoBehaviour
{
    [SerializeField] Button homeButton;

    private void Start()
    {
        homeButton.onClick.AddListener(ClickHomeButton);
    }
    void ClickHomeButton()
    {
        UIManager.Instance.OnEnablePanelGameLevel();
    }
}
