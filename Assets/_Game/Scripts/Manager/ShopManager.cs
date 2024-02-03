using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : Singleton<ShopManager>
{
    [SerializeField] private GameObject decisionPanel;
    [SerializeField] private Button confirmBtn;
    [SerializeField] private Button escBtn;

    [SerializeField] private Button ad120Btn;
    [SerializeField] private Button m1KBtn;
    [SerializeField] private Button m3KBtn;
    [SerializeField] private Button m5KBtn;
    [SerializeField] private Button m25KBtn;
    [SerializeField] private Button m50KBtn;

    [SerializeField] private TextMeshProUGUI diamondShopText;

    private int index;

    public TextMeshProUGUI DiamondShopText { get => diamondShopText; set => diamondShopText = value; }

    private void Start()
    {
        confirmBtn.onClick.AddListener(OnClickConfirmBtn);
        escBtn.onClick.AddListener(OnClickCloseDesPanel);

        ad120Btn.onClick.AddListener(OnClickAd120Btn);
        m1KBtn.onClick.AddListener(OnClickAdm1KBtn);
        m3KBtn.onClick.AddListener(OnClickAdm3KBtn);
        m5KBtn.onClick.AddListener (OnClickAdm5KBtn);
        m25KBtn.onClick.AddListener(OnClickAdm25KBtn);
        m50KBtn.onClick.AddListener(OnClickAdm50KBtn);
    }

    public void OnClickAd120Btn()
    {
        index = 120;
        decisionPanel.SetActive(true);
    }

    public void OnClickAdm1KBtn()
    {
        index = 1000;
        decisionPanel.SetActive(true);
    }

    public void OnClickAdm3KBtn()
    {
        index = 3000;
        decisionPanel.SetActive(true);
    }

    public void OnClickAdm5KBtn()
    {
        index = 5000;
        decisionPanel.SetActive(true);
    }

    public void OnClickAdm25KBtn()
    {
        index = 25000;
        decisionPanel.SetActive(true);
    }

    public void OnClickAdm50KBtn()
    {
        index = 50000;
        decisionPanel.SetActive(true);
    }

    public void OnClickConfirmBtn()
    {
        DataManager.Instance.dataDynamic.CurrentDynament += index;
        UIManager.Instance.UpdateScoreDyamon();
        decisionPanel.SetActive(false);
    }

    public void OnClickCloseDesPanel()
    {
        decisionPanel.SetActive(false);
    }
}
