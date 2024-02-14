using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject gamePlay;
    [SerializeField] private Block highBlock;
    [SerializeField] private GameObject homeCanvas;
    [SerializeField] private GameObject playCanvas;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject themeCanvas;
    [SerializeField] private GameObject swapCanvas;
    [SerializeField] private GameObject hammerCanvas;
    [SerializeField] private GameObject bottonButtons;
    [SerializeField] private GameObject settingCanvas;
    [SerializeField] private GameObject shopCanvas;
    [SerializeField] private GameObject tutorialCanvas;

    [SerializeField] private Button playBtn;
    [SerializeField] private Button pauseBtn;
    [SerializeField] private Button swapBtn;
    [SerializeField] private Button hammerBtn;
    [SerializeField] private Button closePauseBtn;
    [SerializeField] private Button homeBtn;
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button restartBtn;

    [SerializeField] private Button settingBtn;
    [SerializeField] private Button backSettingBtn;
    [SerializeField] private Button shopBtn;
    [SerializeField] private Button backShopBtn;
    [SerializeField] private Button themeBtn;
    [SerializeField] private Button backThemeBtn;

    [SerializeField] private TextMeshProUGUI totalScoreText;
    [SerializeField] private TextMeshProUGUI curentHighScoreTextInPlay;
    [SerializeField] private TextMeshProUGUI curentHighScoreTextInHome;
    [SerializeField] private TextMeshProUGUI currentDynamonTextInPlay;
    [SerializeField] private TextMeshProUGUI currentDynamonTextInHome;

    [SerializeField] private TextMeshProUGUI outMoneyTMP;

    public GameObject GamePlay { get => gamePlay; set => gamePlay = value; }
    public GameObject TutorialCanvas { get => tutorialCanvas; set => tutorialCanvas = value; }

    private void Start()
    {
        GamePlay.SetActive(false);
        UpdateScoreDyamon();
        UpdateHighBlock();
        playBtn.onClick.AddListener(OnClickPlayBtn);
        settingBtn.onClick.AddListener(OnClickSettingBtn);
        backSettingBtn.onClick.AddListener(OnClickBackSetting);
        shopBtn.onClick.AddListener(OnClickShopBtn);
        backShopBtn.onClick.AddListener(OnClickBackShopBtn);
        themeBtn.onClick.AddListener(OnClickThemeBtn);
        backThemeBtn.onClick.AddListener(OnClickBackThemeBtn);
        pauseBtn.onClick.AddListener(OnClickPauseBtn);
        homeBtn.onClick.AddListener(OnClickHomeBtn);
        closePauseBtn.onClick.AddListener(OnClickResumeBtn);
        resumeBtn.onClick.AddListener(OnClickResumeBtn);
        restartBtn.onClick.AddListener(OnClickRestartBtn);
        swapBtn.onClick.AddListener(OnClickSwapBtn);
        hammerBtn.onClick.AddListener(OnClickHammerBtn);
        Time.timeScale = 0f;
    }
    public void TurnOnBottonButtons()
    {
        swapCanvas.SetActive(false);
        hammerCanvas.SetActive(false);
        bottonButtons.SetActive(true);
    }
    private void OnClickHammerBtn()
    {
        if (GameManager.Instance.gameState == 1)
        {
            if (DataManager.Instance.dataDynamic.currentDynament >= 170)
            {
                Debug.Log("out");
                DataManager.Instance.dataDynamic.currentDynament -= 170;
                UpdateScoreDyamon();
                GameManager.Instance.ChangeState(new HammerState());
                hammerCanvas.SetActive(true);
                bottonButtons.SetActive(false);
            }
            else
            {
                outMoneyTMP.gameObject.SetActive(true);
                Invoke(nameof(DeActiveOutMoney), 1.5f);
            }
        }
    }

    private void OnClickSwapBtn()
    {
        if (GameManager.Instance.gameState == 1)
        {
            if (DataManager.Instance.dataDynamic.currentDynament >= 170)
            {
                DataManager.Instance.dataDynamic.currentDynament -= 170;
                UpdateScoreDyamon();
                GameManager.Instance.ChangeState(new SwapState());
                swapCanvas.SetActive(true);
                bottonButtons.SetActive(false);
            }
            else
            {
                outMoneyTMP.gameObject.SetActive(true);
                Invoke(nameof(DeActiveOutMoney), 1.5f);
            }
        }
    }

    public void DeActiveOutMoney()
    {
        outMoneyTMP.gameObject.SetActive(false);
    }

    public void UpdateHighBlock()
    {
        highBlock.NumberText.text = GameManager.Instance.numberSO.listNumber[DataManager.Instance.dataDynamic.currentHighBlock].number.ToString();
        highBlock.GetComponent<Image>().color = GameManager.Instance.numberSO.listNumber[DataManager.Instance.dataDynamic.currentHighBlock].color;
    }
    public void UpdateScoreDyamon()
    {
        curentHighScoreTextInPlay.text = DataManager.Instance.dataDynamic.currentHighScore.ToString();
        curentHighScoreTextInHome.text = DataManager.Instance.dataDynamic.currentHighScore.ToString();
        currentDynamonTextInPlay.text = DataManager.Instance.dataDynamic.currentDynament.ToString();
        currentDynamonTextInHome.text = DataManager.Instance.dataDynamic.currentDynament.ToString();
        ShopManager.Instance.DiamondShopText.text = DataManager.Instance.dataDynamic.currentDynament.ToString();
    }
    public void UpdateTotalScore()
    {
        totalScoreText.text = GameManager.Instance.TotalScore.ToString();
        curentHighScoreTextInPlay.text = DataManager.Instance.dataDynamic.currentHighScore.ToString();
        curentHighScoreTextInHome.text = DataManager.Instance.dataDynamic.currentHighScore.ToString();
        currentDynamonTextInPlay.text = DataManager.Instance.dataDynamic.currentDynament.ToString();
        currentDynamonTextInHome.text = DataManager.Instance.dataDynamic.currentDynament.ToString();
    }
    public void OnClickPlayBtn()
    {
        playCanvas.SetActive(true);
        homeCanvas.SetActive(false);
        if (DataManager.Instance.dataDynamic.firstTimePlaying == true)
        {
            TutorialCanvas.SetActive(true);
        }
        else
        {
            GamePlay.SetActive(true);
        }
        Time.timeScale = 1.0f;
        DataManager.Instance.dataDynamic.firstTimePlaying = false;
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

    public void OnClickThemeBtn()
    {
        homeCanvas.SetActive(false);
        themeCanvas.SetActive(true);
    }

    public void OnClickBackThemeBtn()
    {
        homeCanvas.SetActive(true);
        themeCanvas.SetActive(false);
    }

    public void OnClickPauseBtn()
    {
        GamePlay.SetActive(false);
        playCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
    }

    public void OnClickHomeBtn()
    {
        homeCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        UpdateHighBlock();
    }

    public void OnClickResumeBtn()
    {
        GamePlay.SetActive(true);
        playCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
    }

    public void OnClickRestartBtn()
    {
        DataManager.Instance.SetPlayerpref();
        SceneManager.LoadScene("SampleScene");
    }
}
