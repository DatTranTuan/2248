using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gamePlay;

    [SerializeField] private GameObject homeCanvas;

    [SerializeField] private Button playBtn;

    private void Start()
    {
        gamePlay.SetActive(false);
        playBtn.onClick.AddListener(OnClickPlayBtn);
        Time.timeScale = 0f;
    }

    public void OnClickPlayBtn()
    {
        gamePlay.SetActive(true);
        homeCanvas.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
