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
