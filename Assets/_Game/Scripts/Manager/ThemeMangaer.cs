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
    [SerializeField] private GameObject themeCanvas;
    [SerializeField] private GameObject settingCanvas;

    [SerializeField] private ThemeItemSo themeItemSo;

    public void ChangeTheme(int index)
    {
        homeCanvas.GetComponent<Image>().sprite = themeItemSo.listThemes[index].wallPaper;
        playCanvas.GetComponent<Image>().sprite = themeItemSo.listThemes[index].wallPaper;
        pauseCanvas.GetComponent<Image>().sprite = themeItemSo.listThemes[index].wallPaper;
        themeCanvas.GetComponent<Image>().sprite = themeItemSo.listThemes[index].wallPaper;
        settingCanvas.GetComponent<Image>().sprite = themeItemSo.listThemes[index].wallPaper;
    }
}
