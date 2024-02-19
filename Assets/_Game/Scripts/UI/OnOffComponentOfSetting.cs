using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class OnOffComponentOfSetting : MonoBehaviour
{ 
    [SerializeField] private Button musicOnOffBtn;
    [SerializeField] private GameObject fill1;
    [SerializeField] private GameObject onHandle1;
    [SerializeField] private GameObject offHandle1;

    private void OnEnable()
    {
        if (DataManager.Instance.dataDynamic.soundStatus)
        {
            fill1.SetActive(true);
            onHandle1.SetActive(true);
            offHandle1.SetActive(false);
        }
        else
        {
            fill1.SetActive(false);
            onHandle1.SetActive(false);
            offHandle1.SetActive(true);
        }
    }

    void Start()
    {
        musicOnOffBtn.onClick.AddListener(MusicOnOffOnclick);
    }
    private void MusicOnOffOnclick()
    {
        bool t = onHandle1.activeInHierarchy;
        fill1.SetActive(!t);
        onHandle1.SetActive(!t);
        offHandle1.SetActive(t);

        if(t)
        {
            // Off Sounds
            DataManager.Instance.dataDynamic.soundStatus = false;
        }
        else
        {
            DataManager.Instance.dataDynamic.soundStatus = true;
        }
    }
}
