using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitState : GameStateBase
{
    public GameInitState()
    {
        state = GameStateEnum.Init;
    }
    override public void Enter()
    {
        base.Enter();
        UIManager.Instance.SetStartBtnVisible(true);
        UIManager.Instance.SetpauseBtnVisible(false);
        UIManager.Instance.SetEndBtnVisible(false);
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
