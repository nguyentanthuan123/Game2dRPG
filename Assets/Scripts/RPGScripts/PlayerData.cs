using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public int currentHealth;
    public int maxHealth;
    public int attackDamage;

    public int soulCollectedData;

    public float[] position;

    public PlayerData(CharacterController characterController, SoulCollected soulCollected)
    {
        currentHealth = characterController.currentHealth;
        maxHealth = characterController.maxHealth;
        attackDamage = characterController.attackDamage;

        soulCollectedData = soulCollected.soulCollect;

        //position = new float[3];
        //position[0] = characterController.transform.position.x;
        //position[1] = characterController.transform.position.y;
        //position[2] = characterController.transform.position.z;

    }
}
