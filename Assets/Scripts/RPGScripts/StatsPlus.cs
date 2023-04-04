using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPlus : ThuanBehaviour
{
    private static SoulCollected instances;

    public static SoulCollected Instances { get => instances; }

    HealthBar healthBar;
    public GameObject healthPlus;
    public GameObject attackPlus;


    protected override void Start()
    {
        LoadPlayer();
    }

    public virtual void HealthPlus()
    {
        CharacterController.Instances.maxHealth += 5;
        healthPlus.GetComponent<Text>().text = CharacterController.Instances.maxHealth.ToString();
        GameObject.Find("HealthBar").GetComponent<HealthBar>().SetMaxHealth(CharacterController.Instances.maxHealth);
        GameObject.Find("HealthBar").GetComponent<HealthBar>().SetHealth(CharacterController.Instances.currentHealth);
    }

    public virtual void AttackPlus()
    {
        CharacterController.Instances.attackDamage += 1;
        attackPlus.GetComponent<Text>().text = CharacterController.Instances.attackDamage.ToString();
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        if (data == null) return;
        CharacterController.Instances.maxHealth = data.healPlusData;
        healthPlus.GetComponent<Text>().text = CharacterController.Instances.maxHealth.ToString();

        CharacterController.Instances.attackDamage = data.attackDamageData;
        attackPlus.GetComponent<Text>().text = CharacterController.Instances.attackDamage.ToString();
    }
}
