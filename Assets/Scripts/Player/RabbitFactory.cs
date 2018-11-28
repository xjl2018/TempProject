using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitFactory : PlayerFactory
{
    override public PlayerBase ProducePlayer()
    {
        var player = base.ProducePlayer();
        if (player == null)
        {
            player = new Rabbit();
        }
        return player;
    }
}
