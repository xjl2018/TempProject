using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : PlayerBase
{

    override public void Init()
    {
        base.Init();
    }

    override public void Eat(FoodBase food)
    {
        //todo: play animator

        UpLevel();
    }

    override public void UpLevel()
    {
        
    }



}
