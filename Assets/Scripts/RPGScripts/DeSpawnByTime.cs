using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawnByTime : Despawn
{
    protected override bool CanDespawn()
    {
        return false;
    }
}
