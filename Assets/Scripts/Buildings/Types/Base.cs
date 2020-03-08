using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : Building
{
    public override void Die()
    {
        GameController.players.RemoveAt(owner);
    }

    public override void Perform()
    {

    }
}
