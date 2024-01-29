using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject gamePlay;

    [SerializeField] private GameObject homeCanvas;
    [SerializeField] private GameObject playCanvas;
    [SerializeField] private GameObject pauseCanvas;

    [SerializeField] private GameObject settingCanvas;
    [SerializeField] private GameObject shopCanvas;

    [SerializeField] private Button playBtn;
    [SerializeField] private Button pauseBtn;
    [SerializeField] private Button closePauseBtn;
    [SerializeField] private Button homeBtn;
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button restartBtn;

    [SerializeField] private Button settingBtn;
    [SerializeField] private Button backSettingBtn;
    [SerializeField] private Button shopBtn;
    [SerializeField] private Button backShopBtn;

    [SerializeField] private TextMeshProUGUI totalScoreText;

    private void Start()
    {
        gamePlay.SetActive(false);

        playBtn.onClick.AddListener(OnClickPlayBtn);
        settingBtn.onClick.AddListener(OnClickSettingBtn);
        backSettingBtn.onClick.AddListener(OnClickBackSetting);
        shopBtn.onClick.AddListener(OnClickShopBtn);
        backShopBtn.onClick.AddListener(OnClickBackShopBtn);

        pauseBtn.onClick.AddListener(OnClickPauseBtn);
        homeBtn.onClick.AddListener(OnClickHomeBtn);
        closePauseBtn.onClick.AddListener(OnClickResumeBtn);
        resumeBtn.onClick.AddListener(OnClickResumeBtn);
        restartBtn.onClick.AddListener(OnClickRestartBtn);

        Time.timeScale = 0f;
    }

    public void UpdateTotalScore()
    {
        totalScoreText.text = GameManager.Instance.TotalScore.ToString();
    }
    public void OnClickPlayBtn()
    {
        gamePlay.SetActive(true);
        playCanvas.SetActive(true);
        homeCanvas.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OnClickSettingBtn()
    {
        homeCanvas.SetActive(false);
        settingCanvas.SetActive(true);
    }

    public void OnClickBackSetting()
    {
        homeCanvas.SetActive(true);
        settingCanvas.SetActive(false);
    }

    public void OnClickShopBtn()
    {
        homeCanvas.SetActive(false);
        shopCanvas.SetActive(true);
    }

    public void OnClickBackShopBtn()
    {
        homeCanvas.SetActive(true);
        shopCanvas.SetActive(false);
    }

    public void OnClickPauseBtn()
    {
        gamePlay.SetActive(false);
        playCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
    }

    public void OnClickHomeBtn()
    {
        homeCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
    }

    public void OnClickResumeBtn()
    {
        gamePlay.SetActive(true);
        playCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
    }

    public void OnClickRestartBtn ()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
