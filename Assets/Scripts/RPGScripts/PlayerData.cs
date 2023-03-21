using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public int health;
    public float[] position;

    public PlayerData(CharacterController characterController)
    {
        health = characterController.currentHealth;

        position = new float[3];
        position[0] = characterController.transform.position.x;
        position[1] = characterController.transform.position.y;
        position[2] = characterController.transform.position.z;

    }
}
