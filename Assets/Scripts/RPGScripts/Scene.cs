using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : ThuanBehaviour
{
    public int sceneBuildIndex;

    public virtual void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public virtual void BackMainMenu()
    {
        CharacterController.Instances.SavePlayer();
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void ResetGame()
    {
        DeleteData.DeletePathData();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            CharacterController.Instances.SavePlayer();
            //Teleport Player
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            //Debug.Log(sceneBuildIndex);
        }
    }
}
