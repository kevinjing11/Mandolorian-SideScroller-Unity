using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = true;
    public Hero player;

    public GameObject pauseMenuUI;
    public GameObject missileLauncher;
    public GameObject laserGun;
    public GameObject spear;

    private GameObject currentWeapon;
   

    void Awake() {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
      
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
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
        player.SavePlayer();
        pauseMenuUI.SetActive(false);
        //time scale is between 0 - 1, with 0 being paused
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadLaser()
    {
        
        player.EquipWeapon(laserGun);
    }

    public void LoadGrenade()
    {
        
        player.EquipWeapon(missileLauncher);
    }

    public void LoadSpear()
    {
        
        player.EquipWeapon(spear);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}