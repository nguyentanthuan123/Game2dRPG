using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public int currentHealthData;
    public int maxHealthData;
    public int attackDamageData;

    public int soulCollectedData;
    public int soulNeedToSellData;

    public int maxHealPlusData;
    public int attackPlusData;

    public float[] position;

    public PlayerData(CharacterController characterController, SoulCollected soulCollected, StatsPlus statsPlus)
    {
        currentHealthData = characterController.currentHealth;
        maxHealthData = characterController.maxHealth;
        attackDamageData = characterController.attackDamage;

        soulCollectedData = soulCollected.soulCollect;
        soulNeedToSellData = soulCollected.soulToNeed;

        maxHealPlusData = CharacterController.Instances.maxHealth;
        attackPlusData = CharacterController.Instances.attackDamage;

        //position = new float[3];
        //position[0] = characterController.transform.position.x;
        //position[1] = characterController.transform.position.y;
        //position[2] = characterController.transform.position.z;

    }
}
