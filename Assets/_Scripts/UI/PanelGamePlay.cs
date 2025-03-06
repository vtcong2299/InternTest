using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGamePlay : MonoBehaviour
{
    [SerializeField] Button homeButton;
    [SerializeField] GameObject jumpButton;
    [SerializeField] GameObject joystick;


    private void Start()
    {
        homeButton.onClick.AddListener(ClickHomeButton);
        if (GameManager.Instance.playOnMobile)
        {
            jumpButton.SetActive(true);
            joystick.SetActive(true);
        }
        else
        {
            jumpButton.SetActive(false);
            joystick.SetActive(false);
        }
    }
    void ClickHomeButton()
    {
        GameManager.Instance.iq = 0;
        UIManager.Instance.OnEnablePanelGameLevel();
    }
}
