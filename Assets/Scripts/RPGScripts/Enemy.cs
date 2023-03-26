using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{

    private Transform player;
    public bool isFlip = false;
    public Animator enAnim;
    public UnityEvent Onhit;

    [Header("Attack")]
    public int attackDamage;
    public Vector3 attackOffset;
    public float attackRange;
    public LayerMask layerMask;
    public Transform attackPoint;

    [Header("Range")]
    public float rangeChase;
    public float rangeAttack;

    [Header("Health")]
    public int currentHealth;
    public int maxHealth = 100;
    public HealthBar healthBar;
    public GameObject healCanvas;


    //// Start is called before the first frame update
    void Start()
    {
        //Health Bar
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        //enemyRg = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public void TakeDamage(int damage)
    {
        Onhit?.Invoke();
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        enAnim.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            GameObject.Find("SpawnEnemy").GetComponent<SpawnEnemy>().SpawnNewEmemy();
            currentHealth = 0;
            Dead();
        }
    }
    private void Dead()
    {
        //Die Animation
        enAnim.SetBool("IsDead", true);
        Debug.Log("Die");
        //Disable Enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        //Destroy Object
        Destroy(healCanvas);
        Destroy(gameObject, 3);
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        pos += transform.up * attackOffset.z;
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, layerMask);
        if (colInfo == null) return;
        colInfo.GetComponent<CharacterController>().TakeDamage(attackDamage);
    }

    public void LookAtPlayer()
    {
        Vector3 flip = transform.localScale;
        flip.z *= -1f;

        if (transform.position.x > player.position.x && isFlip)
        {
            transform.localScale = flip;
            transform.Rotate(0f, 180f, 0f);
            isFlip = false;
        }
        else if (transform.position.x < player.position.x && !isFlip)
        {
            transform.localScale = flip;
            transform.Rotate(0f, 180f, 0f);
            isFlip = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangeChase);
        Gizmos.DrawWireSphere(transform.position, rangeAttack);
    }

    //public void MoveAttack(Vector2 dir)
    //{
    //    //Flip
    //    if (transform.position.x > player.transform.position.x)
    //    {
    //        enemyRg.transform.localScale = new Vector2(1, 1);
    //    }
    //    if (transform.position.x < player.transform.position.x)
    //    {
    //        enemyRg.transform.localScale = new Vector2(-1, 1);
    //    }
    //    enemyRg.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    //    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);

    //    //Move toward
    //    float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

    //    //Atack
    //    if (distanceFromPlayer < rangeChase && distanceFromPlayer > rangeAttack)
    //    {
    //        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
    //        enAnim.SetTrigger("Attack");
    //    }
    //    else if (distanceFromPlayer <= rangeAttack)
    //    {
    //        enAnim.SetTrigger("Attack");
    //    }
    //    Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
    //    foreach (Collider2D playerCol in hitPlayer)
    //    {
    //        playerCol.GetComponent<CharacterController>().TakeDamage(attackDamage);
    //    }
    //}
}
