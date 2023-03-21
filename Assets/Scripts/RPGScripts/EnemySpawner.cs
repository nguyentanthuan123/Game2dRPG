using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawn
{
    private static EnemySpawner instances;

    public static EnemySpawner Instances { get => instances;}

    public static string enemyOne = "StaticEnemy";

    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instances != null) Debug.LogError("Only 1 Enemy allow to exist");
        EnemySpawner.instances = this;
    }


}
