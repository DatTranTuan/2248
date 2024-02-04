using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W3 : Singleton<W3>
{
    [SerializeField] private Button buyBtn;
    [SerializeField] private Button equipBtn;
    [SerializeField] private Button equipedBtn;

    private void Start()
    {
        buyBtn.onClick.AddListener(OnClickBuyBtn);
        equipBtn.onClick.AddListener(OnClickEquipBtn);
    }

    public void OnClickBuyBtn()
    {
        if (DataManager.Instance.dataDynamic.CurrentDynament >= 150)
        {
            DataManager.Instance.dataDynamic.CurrentDynament -= 150;
            UIManager.Instance.UpdateScoreDyamon();
            equipBtn.gameObject.SetActive(true);
            buyBtn.gameObject.SetActive(false);
        }

    }

    public void SetEquipBtn()
    {
        if (equipedBtn.gameObject.activeInHierarchy)
        {
            equipedBtn.gameObject.SetActive(false);
            equipBtn.gameObject.SetActive(true);
        }
    }

    public void OnClickEquipBtn()
    {
        equipedBtn.gameObject.SetActive(true);
        equipBtn.gameObject.SetActive(false);
        ChangeTheme(2);
        W2.Instance.SetEquipBtn();
        W4.Instance.SetEquipBtn();
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
