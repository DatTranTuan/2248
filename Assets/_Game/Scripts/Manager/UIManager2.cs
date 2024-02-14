using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager2 : Singleton<UIManager2>
{
    [SerializeField] private GameObject loadCanvas;

    [SerializeField] private Slider loadSlider;
    [SerializeField] private TextMeshProUGUI textLoad;

    [SerializeField] private float speed;

    private void Start()
    {
        loadSlider.value = 0f;
        textLoad.text = "0%";
    }

    private void Update()
    {
        Debug.Log(loadSlider.value);
        loadSlider.value += Time.deltaTime * speed;
        textLoad.text = Mathf.Round(loadSlider.value) + "%";

        if (loadSlider.value >= 100f)
        {
            loadCanvas.SetActive(false);
            UIManager.Instance.HomeCanvas.SetActive(true);
        }
    }
}
