using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMoveController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float runspeed;
    public Joystick joystick;
    //float horizotalMove = 0f;
    private Animator anim;

    public Slider slider;
    public int currentHealth;
    public int maxHealth = 100;
    public HealthBar healthBar;

    public int damageDeal = 3;
    private void Start()
    {
        slider.fillRect.GetComponent<Image>().color = Color.green;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(20);
        //}
    }
    void FixedUpdate()
    {
        CharacterMoveByJoyStick();
    }
    public void CharacterMoveByJoyStick()
    {
        if(joystick.Horizontal != 0)
        {
            rb.velocity = new Vector2(joystick.Horizontal * runspeed, joystick.Vertical * runspeed);
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
            rb.velocity = Vector2.zero;
        }
        if (joystick.Horizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if (joystick.Horizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        //if(joystick.Horizontal >= .2f)
        //{
        //    horizotalMove = runspeed;
        //}
        //else if(joystick.Horizontal < -.2f)
        //{
        //    horizotalMove = -runspeed;
        //}
        //else
        //{
        //    horizotalMove = 0f;
        //}
    }
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            TakeDamage(damageDeal);
        }
    }
}
