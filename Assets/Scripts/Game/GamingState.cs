using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamingState : GameStateBase
{
    private bool isGameEnd = false;


    private float lastFoodTime = 0;  //上一次产生食物的时间
    private float foodTimeDuration = 4; //食物产生时间间隔，随关卡等级变化

    private List<FoodBase> foodList = new List<FoodBase>();   //当前产生的食物

    public GamingState()
    {
        state = GameStateEnum.Gaming;
    }

    override public void Enter()
    {
        base.Enter();
        if (isGameEnd)
        {
            GameManager.Instance.ChangeGameState(GameStateEnum.End);
            return;
        }
        EventDispatcher.AddEventListener(GameManager.Instance.CheckGameEndEvent, CheckGameEnd);
        PlayerManager.Instance.Reset();

        UIManager.Instance.SetEndBtnVisible(true);
        UIManager.Instance.SetpauseBtnVisible(true);
        UIManager.Instance.SetStartBtnVisible(false);
    }

    override public void UpdateProcess()
    {
        base.UpdateProcess();
        if (isGameEnd)
        {
            GameManager.Instance.ChangeGameState(GameStateEnum.End);
            return;
        }
        HandleFood();
        for (int i = 0; i < foodList.Count; i++)
        {
            foodList[i].Update();
        }
    }

    override public void Exit()
    {
        base.Exit();
        EventDispatcher.removeEventListener(GameManager.Instance.CheckGameEndEvent, CheckGameEnd);

        foreach (var food in foodList)
        {
            FoodManager.Instance.CollectFood(food);
        }
        foodList.Clear();
    }

    private void CheckGameEnd()
    {
        GameManager.Instance.ChangeGameState(GameStateEnum.End);
    }

    private void HandleFood()
    {
        if (Time.time - lastFoodTime < foodTimeDuration)
        {
            return;
        }
        lastFoodTime = Time.time;
        var food = FoodManager.Instance.ProduceFood();
        food.SetVisible(true);

    }
}
