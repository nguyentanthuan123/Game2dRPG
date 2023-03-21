using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject closeBtnPanel;
    public GameObject menuSetting;

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
            bool isActive = menuSetting.activeSelf;
            menuSetting.SetActive(!isActive);
            Time.timeScale = 0;
        }
    }

    public void Continue()
    {
        menuSetting.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenRestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
