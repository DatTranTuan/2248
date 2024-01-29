using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gamePlay;

    [SerializeField] private GameObject homeCanvas;
    [SerializeField] private GameObject playCanvas;
    [SerializeField] private GameObject pauseCanvas;

    [SerializeField] private GameObject settingCanvas;

    [SerializeField] private Button playBtn;
    [SerializeField] private Button pauseBtn;
    [SerializeField] private Button closePauseBtn;
    [SerializeField] private Button homeBtn;
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button restartBtn;

    [SerializeField] private Button settingBtn;
    [SerializeField] private Button backSettingBtn;

    private void Start()
    {
        gamePlay.SetActive(false);

        playBtn.onClick.AddListener(OnClickPlayBtn);
        settingBtn.onClick.AddListener(OnClickSettingBtn);
        backSettingBtn.onClick.AddListener(OnClickBackSetting);

        pauseBtn.onClick.AddListener(OnClickPauseBtn);
        homeBtn.onClick.AddListener(OnClickHomeBtn);
        closePauseBtn.onClick.AddListener(OnClickResumeBtn);
        resumeBtn.onClick.AddListener(OnClickResumeBtn);
        restartBtn.onClick.AddListener(OnClickRestartBtn);

        Time.timeScale = 0f;
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
