using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject homeCanvas;

    [SerializeField] private Button playBtn;

    private void Start()
    {
        playBtn.onClick.AddListener(OnClickPlayBtn);
        Time.timeScale = 0f;
    }

    public void OnClickPlayBtn()
    {
        homeCanvas.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
