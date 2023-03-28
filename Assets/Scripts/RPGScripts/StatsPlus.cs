using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPlus : ThuanBehaviour
{
    HealthBar healthBar;
    [SerializeField] private GameObject healthPlus;
    [SerializeField] private GameObject attackPlus;

    protected override void Start()
    {
        healthPlus.GetComponent<Text>().text = CharacterController.Instances.maxHealth.ToString();
        attackPlus.GetComponent<Text>().text = CharacterController.Instances.attackDamage.ToString();
    }
    public virtual void HealthPlus()
    {
        CharacterController.Instances.maxHealth += 5; ;
        healthPlus.GetComponent<Text>().text = CharacterController.Instances.maxHealth.ToString();
        GameObject.Find("HealthBar").GetComponent<HealthBar>().SetMaxHealth(CharacterController.Instances.maxHealth);
        GameObject.Find("HealthBar").GetComponent<HealthBar>().SetHealth(CharacterController.Instances.currentHealth);
    }

    public virtual void AttackPlus()
    {
        CharacterController.Instances.attackDamage += 1;
        attackPlus.GetComponent<Text>().text = CharacterController.Instances.attackDamage.ToString();
    }
}
