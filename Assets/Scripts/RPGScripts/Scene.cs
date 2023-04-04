using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : ThuanBehaviour
{
    public int sceneBuildIndex;

    public virtual void PlayGame()
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public virtual void BackMainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

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
