using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseState : GameStateBase
{
    public GamePauseState()
    {
        state = GameStateEnum.Pause;
    }
    override public void Enter()
    {
        base.Enter();
        UIManager.Instance.SetPausePanelVisible(true);
    }

    override public void UpdateProcess()
    {
        base.UpdateProcess();
    }

    override public void Exit()
    {
        base.Exit();
        UIManager.Instance.SetPausePanelVisible(false);
    }
}
