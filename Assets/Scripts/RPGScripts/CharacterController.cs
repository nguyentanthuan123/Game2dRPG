using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    GameController gameController;
    public GameObject restartBtn;

    [Header("Movement")]
    public Rigidbody2D rb;
    Vector2 movement;
    public float runspeed;
    public Animator anim;
    public LayerMask enemyLayers;
    //public Joystick joystick;

    [Header("Health")]
    public int currentHealth;
    public int maxHealth = 100;
    public HealthBar healthBar;

    [Header("Attack")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public bool isAttack;

    [Header("Attack Combat")]
    public float attackRate = 1f;
    float nextAttackTime = 0f;
    public int combo;
    public bool atackCombo;
    public Animator animSkill;

    [Header("Ability Cooldown")]
    public Image abilityImage;
    public float cooldown1 = 10;
    bool isCooldown = false;
    public KeyCode ability1;
    // Start is called before the first frame update
    void Start()
    {
        abilityImage.fillAmount = 0;

        //Health Bar
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);


        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        animSkill = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Attack();

        CharacterMoveByJoyStick();

        //if(Input.GetKeyDown(KeyCode.Space)) TakeDamage(20);

        Ability1();

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * runspeed * Time.fixedDeltaTime);
    }

    void Ability1()
    {
        if (currentHealth < maxHealth)
        {
            if (Input.GetKeyDown(ability1) && isCooldown == false)
            {
                isCooldown = true;
                abilityImage.fillAmount = 1;
                currentHealth += 12;
                healthBar.SetHealth(currentHealth);
            }
        }
        else if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        if(isCooldown)
        {
            abilityImage.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if(abilityImage.fillAmount <= 0)
            {
                abilityImage.fillAmount = 0;
                isCooldown = false;
            }
        }
    }


    private void CharacterMoveByJoyStick()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x  != 0 || movement.y != 0)
        {

            rb.velocity = new Vector2(movement.x * runspeed, movement.y * runspeed);
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
            rb.velocity = Vector2.zero;

        }
        if (movement.x > 0 )
        {
            gameObject.transform.localScale = new Vector2(1, 1);
        }
        if (movement.x < 0)
        {
            gameObject.transform.localScale = new Vector2(-1, 1);
        }

        //if (joystick.Horizontal != 0)
        //{
        //    rb.velocity = new Vector2(joystick.Horizontal * runspeed, joystick.Vertical * runspeed);
        //    anim.SetBool("IsRunning", true);
        //}
        //else
        //{
        //    anim.SetBool("IsRunning", false);
        //    rb.velocity = Vector2.zero;
        //}
        //if (joystick.Horizontal > 0)
        //{
        //    gameObject.transform.localScale = new Vector2(1, 1);
        //}
        //if (joystick.Horizontal < 0)
        //{
        //    gameObject.transform.localScale = new Vector2(-1, 1);
        //}
    }

    private void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.J))  //&& !atackCombo)
            {
                //Combo();
                isAttack = true;
                anim.SetTrigger("IsAttack");
                Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

                foreach (Collider2D enemy in hitEnemy)
                {
                    Debug.Log("hit me" + enemy.name);
                    enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                }
                nextAttackTime = Time.time + 1f / attackRate;

            }
            else
            {
                isAttack = false;
            }

        }
    }

    //public void Combo()
    //{
    //    atackCombo = true;
    //    anim.SetTrigger("" + combo);
    //    if(combo == 1)
    //    {
    //        animSkill.SetTrigger("1");
    //    }
    //}

    //public void StartCombo()
    //{
    //    atackCombo = false;
    //    if(combo<2)
    //    {
    //        combo++;
    //    }
    //}

    //public void FinishAnim()
    //{
    //    atackCombo = false;
    //    combo = 0;
    //}

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        //anim.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Dead();

            Time.timeScale = 0;
            restartBtn.SetActive(true);
        }
    }

    private void Dead()
    {
        //Die Animation
        anim.SetBool("IsDead", true);
        Debug.Log("Die");
        //Disable Enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        currentHealth = data.health;
        healthBar.SetHealth(currentHealth);

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
