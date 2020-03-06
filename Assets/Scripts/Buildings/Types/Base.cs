using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : Building
{
    public override void Die()
    {
        GameController.instance.remainingPlayers -= 1;
    }

    public override void Perform()
    {

    }
}
