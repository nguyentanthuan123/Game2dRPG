using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [Header("Bullet")]
    public GameObject bullet;
    public Transform bulletParent;

    public void BulletSpawn()
    {
        Instantiate(bullet, bulletParent.transform.position, bulletParent.rotation);

    }
}
