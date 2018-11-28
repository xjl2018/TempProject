using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndState : GameStateBase
{
    public GameEndState()
    {
        state = GameStateEnum.End;
    }

    override public void Enter()
    {
        base.Enter();

        UIManager.Instance.SetStartBtnVisible(true);
        UIManager.Instance.SetEndBtnVisible(false);
        UIManager.Instance.SetpauseBtnVisible(false);
    }

    override public void UpdateProcess()
    {
        base.UpdateProcess();
    }

    override public void Exit()
    {
        base.Exit();
    }
}
