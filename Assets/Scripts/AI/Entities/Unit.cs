using UnityEngine;
using System.Collections;

public class Unit : Entity
{
    public override void Die()
    {
        gameObject.SetActive(false);
    }
}
