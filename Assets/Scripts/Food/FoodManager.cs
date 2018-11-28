using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FoodManager
{
    private static FoodManager _instance;
    public static FoodManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new FoodManager();
            }
            return _instance;
        }
    }

    private List<FoodFactory> foodFactories = new List<FoodFactory>();

    public void Init()
    {
        RegisterFactory(new MilkFactory());
        RegisterFactory(new HamburgerFactory());
    }

    private void RegisterFactory(FoodFactory factory)
    {
        foodFactories.Add(factory);

    }

    public FoodBase ProduceFood()
    {
        FoodFactory factory = RandomGetFoodFactory();
        if (factory == null)
            return null;
        FoodBase food = factory.ProduceFood();
        return food;
    }

    public FoodBase ProduceFood(Type type)
    {
        foreach (var factory in foodFactories)
        {
            if (factory.GetType() == type)
            {
                return factory.ProduceFood();
            }
        }
        return null;
    }

    private FoodFactory RandomGetFoodFactory()
    {
        if (foodFactories.Count == 0)
            return null;
        int index = UnityEngine.Random.Range(0, foodFactories.Count);
        return foodFactories[index];
    }

}
