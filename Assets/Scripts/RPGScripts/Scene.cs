using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public int sceneBuildIndex;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //Teleport Player
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            //Debug.Log(sceneBuildIndex);
        }
    }
}
