using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI number;

    public TextMeshProUGUI Number { get => number; set => number = value; }
}
