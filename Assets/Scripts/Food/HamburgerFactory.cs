using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerFactory : FoodFactory
{
    override public FoodBase ProduceFood()
    {
        FoodBase food = base.ProduceFood();
        if (food == null)
        {
            var foodGo = GameObject.Instantiate(UIManager.Instance.foodTemplate);
            food = foodGo.AddComponent<Hamburger>();
            foodListPool.Add(food);
        }
        return food;
    }
}
