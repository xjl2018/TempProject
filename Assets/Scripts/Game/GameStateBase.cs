using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameStateBase
{
    public GameStateEnum state;
    public GameStateBase()
    {
        
    }
    public virtual void Enter()
    {
        Debug.Log("state enter: " + state);
    }

    public virtual void UpdateProcess()
    {

    }

    public virtual void Exit()
    {
        Debug.Log("state exit: " + state);
    }

    public virtual void Pause()
    {
        Debug.Log("state pause: " + state);
    }

    public virtual void Resume()
    {
        Debug.Log("state resume: " + state);
    }
}
