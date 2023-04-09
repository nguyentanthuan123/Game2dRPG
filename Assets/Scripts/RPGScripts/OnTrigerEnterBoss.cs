using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigerEnterBoss : MonoBehaviour
{
    public GameObject wall;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            wall.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.gameObject.SetActive(false);
    }
}
