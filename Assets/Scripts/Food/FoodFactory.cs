using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FoodFactory
{
    public List<FoodBase> foodListPool = new List<FoodBase>();

    public virtual FoodBase ProduceFood()
    {
        return GetFoodFromPool();
    }

    private FoodBase GetFoodFromPool()
    {
        foreach (var food in foodListPool)
        {
            if (food.IsFinish)
            {
                food.Reset();
                return food;
            }
        }
        return null;
    }

  

}