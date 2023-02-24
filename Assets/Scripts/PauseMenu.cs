using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool isDed = false;
    public bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject DeathMenuUI;


    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().playerHp < 0f)
        {           
            DeathMenu();                    
        }else if((GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().playerHp > 0f) && !isPaused)
        {
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

   public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void DeathMenu()
    {
            DeathMenuUI.SetActive(true);
            Time.timeScale = 0f;               
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
