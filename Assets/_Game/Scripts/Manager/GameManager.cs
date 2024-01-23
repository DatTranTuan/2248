using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Block block;
    [SerializeField] private NumberSO numberSO;
    [SerializeField] private int minNum;
    [SerializeField] private int maxNum;

    private IState currentState;

    private void Start()
    {

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Block blockTmp = Instantiate(block);
                blockTmp.transform.position = new Vector2(i, j);
                int numberType = Random.Range(minNum, maxNum);
                blockTmp.NumberText.text = numberSO.listNumber[numberType].number.ToString();
                blockTmp.GetComponent<SpriteRenderer>().material.color = numberSO.listNumber[numberType].color;
                blockTmp.Number = numberType;
            }
        }
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
}
