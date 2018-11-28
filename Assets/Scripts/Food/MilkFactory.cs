using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkFactory : FoodFactory
{
    override public FoodBase ProduceFood()
    {
        FoodBase food = base.ProduceFood();
        if (food == null)
        {
            var foodGo = GameObject.Instantiate(UIManager.Instance.foodTemplate);
            food = foodGo.AddComponent<Milk>();
            foodListPool.Add(food);

        }
        return food;
    }
}
