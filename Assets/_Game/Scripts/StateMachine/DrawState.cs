using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawState : IState
{
    public void OnEnter(GameManager gM)
    {
    }

    public void OnExecute(GameManager gM)
    {
        gM.DrawProces();
    }

    public void OnExit(GameManager gM)
    {
    }
}
