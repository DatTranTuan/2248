using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberText;
    [SerializeField] private int number;

    public TextMeshProUGUI NumberText { get => numberText; set => numberText = value; }
    public int Number { get => number; set => number = value; }
}
