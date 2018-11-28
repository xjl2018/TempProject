using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFactory : PlayerFactory
{
    override public PlayerBase ProducePlayer()
    {
        var player = base.ProducePlayer();
        if (player == null)
        {
            player = new Cat();
        }
        return player;
    }
}
