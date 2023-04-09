using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed;
    public int bulletDamage;
    public GameObject bulletEffect;

    GameObject target;
    Rigidbody2D bulletRB;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * bulletSpeed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);

        float rot = Mathf.Atan2(-moveDir.x, -moveDir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);

        Destroy(this.gameObject, 2);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterController characterController = collision.GetComponent<CharacterController>();
        if(characterController != null)
        {
            characterController.TakeDamage(bulletDamage);
        }
        Instantiate(bulletEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
