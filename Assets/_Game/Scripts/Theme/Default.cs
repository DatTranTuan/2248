using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Default : Singleton<Default>
{
    [SerializeField] private Button buyBtn;
    [SerializeField] private Button equipBtn;
    [SerializeField] private Button equipedBtn;

    private void Start()
    {
        buyBtn.onClick.AddListener(OnClickBuyBtn);
        equipBtn.onClick.AddListener(OnClickEquipBtn);
        switch (DataManager.Instance.dataDynamic.buyingSatus[4])
        {
            case BuyingStatus.BUY:
                equipBtn.gameObject.SetActive(true);
                break;
            case BuyingStatus.NOTBUY:
                buyBtn.gameObject.SetActive(true);
                break;
            case BuyingStatus.USING:
                equipedBtn.gameObject.SetActive(true);
                //ChangeTheme(4);
                break;
        }
    }

    public void OnClickBuyBtn()
    {
        if (DataManager.Instance.dataDynamic.currentDynament >= 150)
        {
            DataManager.Instance.dataDynamic.currentDynament -= 150;
            UIManager.Instance.UpdateScoreDyamon();
            equipBtn.gameObject.SetActive(true);
            buyBtn.gameObject.SetActive(false);
        }

    }

    public void SetEquipBtn()
    {
        if (equipedBtn.gameObject.activeInHierarchy)
        {
            DataManager.Instance.dataDynamic.buyingSatus[4] = BuyingStatus.BUY;
            equipedBtn.gameObject.SetActive(false);
            equipBtn.gameObject.SetActive(true);
        }
    }

    public void OnClickEquipBtn()
    {
        DataManager.Instance.dataDynamic.currentTheme = 4;
        DataManager.Instance.dataDynamic.buyingSatus[4] = BuyingStatus.USING;
        equipedBtn.gameObject.SetActive(true);
        equipBtn.gameObject.SetActive(false);
        ChangeTheme(4);
        W2.Instance.SetEquipBtn();
        W4.Instance.SetEquipBtn();
        W3.Instance.SetEquipBtn();
        W1.Instance.SetEquipBtn();
    }

    public void ChangeTheme(int index)
    {
        ThemeMangaer.Instance.HomeCanvas.GetComponent<Image>().sprite = ThemeMangaer.Instance.ThemeSO.listTheme[index].themeSprite;
        ThemeMangaer.Instance.PlayCanvas.GetComponent<Image>().sprite = ThemeMangaer.Instance.ThemeSO.listTheme[index].themeSprite;
        ThemeMangaer.Instance.PauseCanvas.GetComponent<Image>().sprite = ThemeMangaer.Instance.ThemeSO.listTheme[index].themeSprite;
        ThemeMangaer.Instance.SettingCanvas.GetComponent<Image>().sprite = ThemeMangaer.Instance.ThemeSO.listTheme[index].themeSprite;
        ThemeMangaer.Instance.ThemeCanvas.GetComponent<Image>().sprite = ThemeMangaer.Instance.ThemeSO.listTheme[index].themeSprite;
        ThemeMangaer.Instance.ShopCanvas.GetComponent<Image>().sprite = ThemeMangaer.Instance.ThemeSO.listTheme[index].themeSprite;
    }
}