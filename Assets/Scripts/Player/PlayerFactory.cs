using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerFactory
{
    public virtual PlayerBase ProducePlayer()
    {
        return null;
    }
}
