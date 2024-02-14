using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThemeMangaer : Singleton<ThemeMangaer> 
{
    [SerializeField] private GameObject homeCanvas;
    [SerializeField] private GameObject playCanvas;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject settingCanvas;
    [SerializeField] private GameObject themeCanvas;
    [SerializeField] private GameObject shopCanvas;

    [SerializeField] private ThemeSO themeSO;
    [SerializeField] private TextMeshProUGUI themeTMP;

    [SerializeField] private GameObject defW;
    [SerializeField] private GameObject W1;
    [SerializeField] private GameObject W2;
    [SerializeField] private GameObject W3;
    [SerializeField] private GameObject W4;

    [SerializeField] private Button previousBtn;
    [SerializeField] private Button nextBtn;
    [SerializeField] private Button escBtb;
    [SerializeField] private int max;

    private int index;

    public GameObject HomeCanvas { get => homeCanvas; set => homeCanvas = value; }
    public GameObject PlayCanvas { get => playCanvas; set => playCanvas = value; }
    public GameObject PauseCanvas { get => pauseCanvas; set => pauseCanvas = value; }
    public GameObject SettingCanvas { get => settingCanvas; set => settingCanvas = value; }
    public GameObject ThemeCanvas { get => themeCanvas; set => themeCanvas = value; }
    public ThemeSO ThemeSO { get => themeSO; set => themeSO = value; }
    public GameObject ShopCanvas { get => shopCanvas; set => shopCanvas = value; }
    private void Start()
    {
        index = 0;
        ChangeTheme(DataManager.Instance.dataDynamic.currentTheme);
        escBtb.onClick.AddListener(OnClickEcsBtn);
        previousBtn.onClick.AddListener(OnClickPreviousBtn);
        nextBtn.onClick.AddListener(OnClickNextBtn);
    }

    public void OnClickEcsBtn()
    {
        homeCanvas.SetActive(true);
        themeCanvas.SetActive(false);
    }
    public void OnClickNextBtn()
    {
        Debug.Log("inside");
        index++;
        ChangeNameThemeText();
        if (index > max) index = 0;
    }

    public void OnClickPreviousBtn()
    {
        Debug.Log("inside");
        index--;
        ChangeNameThemeText();
        if (index < 0) index = max;
    }


    public void ChangeNameThemeText()
    {
        themeTMP.text = themeSO.listTheme[index].themeName;
        if (index == 0)
        {
            if (W1.activeInHierarchy)
            {
                W1.SetActive(false);
                defW.SetActive(true);
            }
            else if (W4.activeInHierarchy)
            {
                W4.SetActive(false);
                defW.SetActive(true);
            }
        }
        else if (index == 1)
        {
            if (defW.activeInHierarchy)
            {
                defW.SetActive(false);
                W1.SetActive(true);
            }
            else if (W2.activeInHierarchy)
            {
                W2.SetActive(false);
                W1.SetActive(true);
            }
        }
        else if (index == 2)
        {
            if (W1.activeInHierarchy)
            {
                W1.SetActive(false);
                W2.SetActive(true);
            }
            else if (W3.activeInHierarchy)
            {
                W3.SetActive(false);
                W2.SetActive(true);
            }
        }
        else if (index == 3)
        {
            if (W2.activeInHierarchy)
            {
                W2.SetActive(false);
                W3.SetActive(true);
            }
            else if (W4.activeInHierarchy)
            {
                W4.SetActive(false);
                W3.SetActive(true);
            }
        }
        else if (index == 4)
        {
            if (W3.activeInHierarchy)
            {
                W3.SetActive(false);
                W4.SetActive(true);
            }
            else if (defW.activeInHierarchy)
            {
                defW.SetActive(false);
                W4.SetActive(true);
            }
        }

    }

    public void ChangeTheme(int index)
    {
        HomeCanvas.GetComponent<Image>().sprite = ThemeSO.listTheme[index].themeSprite;
        PlayCanvas.GetComponent<Image>().sprite = ThemeSO.listTheme[index].themeSprite;
        SettingCanvas.GetComponent<Image>().sprite = ThemeSO.listTheme[index].themeSprite;
        ThemeCanvas.GetComponent<Image>().sprite = ThemeSO.listTheme[index].themeSprite;
        ShopCanvas.GetComponent<Image>().sprite = ThemeSO.listTheme[index].themeSprite;
    }
}
