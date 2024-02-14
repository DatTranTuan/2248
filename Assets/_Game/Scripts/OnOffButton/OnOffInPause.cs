using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OnOffInPause : MonoBehaviour
{
    [SerializeField] private Button notificaitonOnOffBtn;
    [SerializeField] private GameObject fill1;
    [SerializeField] private GameObject fill2;
    [SerializeField] private GameObject onHandle1;
    [SerializeField] private GameObject onHandle2;
    [SerializeField] private GameObject offHandle2;
    [SerializeField] private GameObject offHandle1;
    [SerializeField] private Button screenShakeOnOffBtn;
    void Start()
    {
        notificaitonOnOffBtn.onClick.AddListener(NotificaitonOnOffOnclick);
        screenShakeOnOffBtn.onClick.AddListener(ScreenShakeOnOffOnclick);
    }
    private void NotificaitonOnOffOnclick()
    {
        bool t = onHandle1.activeInHierarchy;
        fill1.SetActive(!t);
        onHandle1.SetActive(!t);
        offHandle1.SetActive(t);
    }
    private void ScreenShakeOnOffOnclick()
    {
        bool t = onHandle2.activeInHierarchy;
        fill2.SetActive(!t);
        onHandle2.SetActive(!t);
        offHandle2.SetActive(t);
    }
}
