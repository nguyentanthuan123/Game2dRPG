using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : ThuanBehaviour
{
    private static CharacterController instances;

    public static CharacterController Instances { get => instances; }

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
    public Vector3 attackOffset;

    [Header("Attack Combat")]
    public float attackRate = 1f;
    float nextAttackTime = 0f;
    public int combo;
    public bool attackCombo;
    public Animator animSkill;

    [Header("Dash")]
    public float dashSpeed;
    public float dashLenght = .5f, dashCooldown = 1f;
    private float activeMovespeed;
    private float dashCounter;
    private float dashCoolCounter;
    public GameObject dashEffect;
    public Animator canAnim;
    //private bool canDash = true;
    //private bool isDashing;
    //public float dashingPower = 50f;
    //public float dashingTime = 0.2f;
    //public float dashingCooldown = 1f;
    //[SerializeField] TrailRenderer trail;

    [Header("Ability Cooldown")]
    public Image abilityImage;
    public float cooldown1 = 10;
    bool isCooldown = false;
    public KeyCode ability1;
    // Start is called before the first frame update
    protected override void Start()
    {
        LoadPlayer();
        abilityImage.fillAmount = 0;

        //Health Bar
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);


        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        animSkill = gameObject.GetComponent<Animator>();

        activeMovespeed = runspeed;
    }

    protected override void Awake()
    {
        base.Awake();
        if (CharacterController.instances != null) Debug.LogError("Only 1 Character allow to exist");
        CharacterController.instances = this;
    }

    // Update is called once per frame
    void Update()
    {

        Attack();

        CharacterMoveByJoyStick();

        //if(Input.GetKeyDown(KeyCode.Space)) TakeDamage(20);

        Ability1();

        Dash();
    }
    void FixedUpdate()
    {
        //if (isDashing) return;
        rb.MovePosition(rb.position + movement * activeMovespeed * Time.fixedDeltaTime);
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
            if (Input.GetKeyDown(KeyCode.J) && attackCombo == false)
            {

                isAttack = true;
                anim.SetTrigger("IsAttack");

                Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

                foreach (Collider2D enemy in hitEnemy)
                {
                    //Debug.Log("hit me" + enemy.name);
                    enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                }
                //Combo();
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
    //    attackCombo = true;
    //    anim.SetTrigger("" + combo);

    //}

    //public void StartCombo()
    //{
    //    attackCombo = false;
    //    if (combo < 1)
    //    {
    //        combo++;
    //    }

    //}

    //IEnumerator FinishAnim()
    //{
    //    attackCombo = false;
    //    combo = 0;
    //    yield return new WaitForSeconds(1f);
    //}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        //anim.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            float timedead = 2f;
            StartCoroutine(WaitTimeShow(timedead)); 

            currentHealth = 0;
            Dead();      
        }
    }
    IEnumerator WaitTimeShow(float t)
    {
        yield return new WaitForSeconds(t);
        Time.timeScale = 0;
        restartBtn.SetActive(true);
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
        SaveSystem.SavePlayer(this,GameObject.Find("SoulText").GetComponent<SoulCollected>(), GameObject.Find("SamuraiPlayer").GetComponent<StatsPlus>());
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        if (data == null) return;
        currentHealth = data.currentHealthData;

        maxHealth = data.maxHealthData;

        attackDamage = data.attackDamageData;

        //Vector3 position;
        //position.x = data.position[0];
        //position.y = data.position[1];
        //position.z = data.position[2];
        //transform.position = position;
    }

    private void OnApplicationQuit()
    {
        SavePlayer();
    }

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {

            if (dashCounter <= 0 && dashCoolCounter <= 0)
            {
                activeMovespeed = dashSpeed;
                dashCounter = dashLenght;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
            }
        }


        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMovespeed = runspeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }
}
