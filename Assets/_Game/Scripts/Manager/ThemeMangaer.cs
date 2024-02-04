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

    public GameObject HomeCanvas { get => homeCanvas; set => homeCanvas = value; }
    public GameObject PlayCanvas { get => playCanvas; set => playCanvas = value; }
    public GameObject PauseCanvas { get => pauseCanvas; set => pauseCanvas = value; }
    public GameObject SettingCanvas { get => settingCanvas; set => settingCanvas = value; }
    public GameObject ThemeCanvas { get => themeCanvas; set => themeCanvas = value; }
    public ThemeSO ThemeSO { get => themeSO; set => themeSO = value; }
    public GameObject ShopCanvas { get => shopCanvas; set => shopCanvas = value; }
}
