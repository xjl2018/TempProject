using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerBase
{
    public const int MAX_LEVEL = 5;
    public int currentLevel;

    protected Image image;

    protected bool isReady;

    protected int score;

    protected Animator animator;

    public bool isFinished;

    public bool isLeftTeam;

    public FoodBase currentFood;

    public virtual void Init()
    {
        SetState(false);

    }

    public virtual void SetState(bool isFinished)
    {
        this.isFinished = isFinished;
        if (isFinished)
        {
            if (isLeftTeam)
            {
                PlayerManager.Instance.AddLeftTeamFinishPlayer(this);
            }
            else
            {
                PlayerManager.Instance.AddRightTeamFinishPlayer(this);
            }
        }
        else
        {
            if (isLeftTeam)
            {
                PlayerManager.Instance.SetCurrentLeftPlayer(this);
            }
            else
            {
                PlayerManager.Instance.SetCurrentRightPlayer(this);
            }
        }
    }

    public void SetCurrentFood(FoodBase food)
    {
        currentFood = food;
        if (isLeftTeam)
        {
            UIManager.Instance.SetLeftPlayerFood(food);
        }
        else
        {
            UIManager.Instance.SetRightPlayerFood(food);
        }
    }

    public virtual void Eat(FoodBase food)
    {
        if (food.GetType() != currentFood.GetType())
        {
            //吃错食物，游戏结束
            GameManager.Instance.ChangeGameState(GameStateEnum.End);
        }
    }

    public virtual void UpLevel()
    {
        currentLevel++;
        if (currentLevel >= MAX_LEVEL)
        {
            //todo: play animator
            SetState(true);
        }
    }

    public virtual void PlayerStartAnimation()
    {

    }

    public virtual void Stop()
    {

    }

    public virtual void Resume()
    {

    }

    public virtual void Clear()
    {

    }
}
