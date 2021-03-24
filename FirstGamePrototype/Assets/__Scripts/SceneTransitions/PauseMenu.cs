using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        StoreWeapon();
        EquipWeapon(laserGun);
    }

    public void LoadGrenade()
    {
        StoreWeapon();
        EquipWeapon(missileLauncher);
    }

    public void LoadSpear()
    {
        StoreWeapon();
        EquipWeapon(spear);
    }

    private void StoreWeapon()
    {
        GameObject mando = player.gameObject;
        GameObject hand = mando.transform.GetChild(3).gameObject;
        GameObject weapon = hand.transform.GetChild(0).gameObject;
        Destroy(weapon);
    }

    private void EquipWeapon(GameObject go)
    {
        GameObject mando = player.gameObject;
        GameObject hand = mando.transform.GetChild(3).gameObject;
        currentWeapon = Instantiate(go);
        currentWeapon.transform.parent = hand.transform;
        Hero hero = mando.GetComponent<Hero>();
        hero.weapon = currentWeapon;
        hero.weapon.transform.position = hand.transform.position;
        hero.weapon.transform.rotation = hand.transform.rotation;
    }
}