using UnityEngine;
using UnityEngine.UI;

public class PanelGameLevel : MonoBehaviour
{
    [SerializeField] Button backButton;
    [SerializeField] Button[] levelButtons = new Button[] { };

    [SerializeField] Sprite buttonOn;
    [SerializeField] Sprite buttonOff;

    private void Start()
    {
        backButton.onClick.AddListener(ClickBackButton);
        levelButtons[0].onClick.AddListener(PressLevel1);
        levelButtons[1].onClick.AddListener(PressLevel2);
        levelButtons[2].onClick.AddListener(PressLevel3);
        levelButtons[3].onClick.AddListener(PressLevel4);
    }
    private void OnEnable()
    {
        LevelManager.Instance.CheckUnLockMap();
    }
    public void ClickBackButton()
    {
        UIManager.Instance.OnDisablePanelGameLevel();
        UIManager.Instance.OnEnablePanelGameStart();
    }
    public void PressLevel1()
    {
        GameManager.Instance.SelectLevel(1);
    }
    public void PressLevel2()
    {
        GameManager.Instance.SelectLevel(2);
    }
    public void PressLevel3()
    {
        GameManager.Instance.SelectLevel(3);
    }
    public void PressLevel4()
    {
        GameManager.Instance.SelectLevel(4);
    }
    public void ChangeImageButton(int index, bool on)
    {
        if (on)
        {
            levelButtons[index].image.sprite = buttonOn;
        }
        else
        {
            levelButtons[index].image.sprite = buttonOff;
        }
    }
}
