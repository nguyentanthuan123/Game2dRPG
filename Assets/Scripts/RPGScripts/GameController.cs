using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject closeBtnPanel;
    public GameObject menuSetting;
    public GameObject openStat;
    public GameObject newGame;
    public GameObject continueGame;
    public GameObject playGame;
    public GameObject openWarRsGame;

    public void OpenPanel()
    {
        if (closeBtnPanel != null)
        {
            Animator animator = closeBtnPanel.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("Open");

                animator.SetBool("Open", !isOpen);
            }
        }
    }
    public void OpenMenu()
    {
        if (menuSetting != null)
        {
            menuSetting.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OpenStat()
    {
        if (menuSetting != null)
        {
            bool isActive = openStat.activeSelf;
            openStat.SetActive(!isActive);

        }
    }

    public void OpenWarning()
    {
        if (openWarRsGame != null)
        {
            openWarRsGame.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Continue()
    {
        menuSetting.SetActive(false);
        Time.timeScale = 1;
    }

    public void Back()
    {
        openWarRsGame.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenRestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        //CharacterController.Instances.currentHealth = CharacterController.Instances.maxHealth;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
