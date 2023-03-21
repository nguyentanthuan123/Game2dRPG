using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D enemyRg;
    private Transform target;
    private Animator enAnim;


    public float attackRadius;
    private float disAttack;
    public float movespeed;
    private Vector2 movement;
    private Vector3 dir;
    private float lockPos = 0;

    public Slider slider;
    public int currentHealth;
    public int maxHealth = 100;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {

        slider.fillRect.GetComponent<Image>().color = Color.red;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        enemyRg = gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        chaseToTarget();
    }
    private void FixedUpdate()
    {
        MoveToCharacter(movement);
    }
    private void chaseToTarget()
    {
        transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);

        disAttack = Vector2.Distance(target.position, transform.position);

        if (disAttack <= attackRadius)
        {
            //isAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whereIsPlayer);
            //transform.LookAt(target);
            //GetComponent<Rigidbody2D>().AddForce(transform.position * movespeed *Time.deltaTime);
            //enemyRg.MovePosition((Vector2)transform.position + (movespeed * Time.deltaTime));
            enAnim.SetBool("IsAttack", true);
            
        }
        else
        {
            enAnim.SetBool("IsAttack", false);
        }
        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        enemyRg.rotation = angle;
        dir.Normalize();
        movement = dir;
    }
    private void MoveToCharacter(Vector2 dir)
    {
        if (transform.position.x > target.transform.position.x)
        {
            //transform.localScale = new Vector2(transform.localScale.x * 1, transform.localScale.y);
            enemyRg.transform.localScale = new Vector2(1, 1);
            healthBar.transform.localScale = new Vector2(1, 1);
            
        }
        if (transform.position.x < target.transform.position.x)
        {
            //transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            enemyRg.transform.localScale = new Vector2(-1, 1);
            healthBar.transform.localScale = new Vector2(1, 1);
        }
        enemyRg.MovePosition((Vector2)transform.position + (dir * movespeed * Time.deltaTime));
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    //private void Flip()
    //{
    //    mustPatrol = false;
    //    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    //    movespeed *= -1;
    //    mustPatrol = true;
    //}
}
