using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberText;
    [SerializeField] private int number;

    private bool isDrag;

    public TextMeshProUGUI NumberText { get => numberText; set => numberText = value; }
    public int Number { get => number; set => number = value; }
    public bool IsDrag { get => isDrag; set => isDrag = value; }
}
