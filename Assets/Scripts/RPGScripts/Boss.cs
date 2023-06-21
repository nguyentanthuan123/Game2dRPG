using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [Header("Bullet")]
    public GameObject bullet;
    public Transform bulletParent;

    public GameObject enemySpawn;

    private void Update()
    {
        Spawn();
    }

    public void BulletSpawn()
    {
        Instantiate(bullet, bulletParent.transform.position, bulletParent.rotation);

    }

    private void Spawn()
    {
        if (currentHealth <= maxHealth / 2)
        {
            enemySpawn.SetActive(true);
        }
    }
}
