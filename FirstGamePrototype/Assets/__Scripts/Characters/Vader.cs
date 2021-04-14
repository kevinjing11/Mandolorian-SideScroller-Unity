using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vader : Enemy
{
    public GameObject[] weapons; //Define array of objects to switch between

    
    private int phaseCounter = 0;
    private int switchInt = 300;
    bool isFiring;
    bool enraged;
    bool isLaser = false;

    //text objects
    public GameObject introText;
    public GameObject laserGun;
    public GameObject halfHealthText;
    public GameObject finalText;
    private int displayedOnce = 0;

    //level loader
    //put the Level Loader object here
    public GameObject levelLoader;
    public GameObject player;

    public override void Start()
    {
        base.Start();
        introText.SetActive(false);
        halfHealthText.SetActive(false);
        finalText.SetActive(false);

    }

    public override void EquipWeapon(GameObject newWeapon)
    {
        base.EquipWeapon(newWeapon); //Load new weapon
        newWeapon.GetComponent<ArmRotator>().pointer = Hero.S.gameObject;
        newWeapon.transform.localScale = new Vector3(2.81f, 2.81f, 1); //Put in vector scaled to vader size appropriately
        
    }

    public void LateUpdate() //Code to constantly check if player is dead
    {
        if(currentHealth <= 100) //half of maxHealth
          
        {
            if (!enraged)
            {
                //
                runSpeed += 0.3f;
                weapon.GetComponent<Weapon>().fireRate -= 0.1f;

                if(Hero.S.gameObject.transform.position.x >= gameObject.transform.position.x) //If enraged while player is to the right
                {
                    gameObject.transform.localScale = new Vector3(3.5f, 3.5f, 2.96f);
                }
                else
                {
                    gameObject.transform.localScale = new Vector3(-3.5f, 3.5f, 2.96f);
                }
            

                enraged = true;
            } 
        }
        if (currentHealth <= 0)
        {
            //final speech
            Destroy(gameObject);
            hero.addCoins(coinReward);
            //can put a delay here, just POC
            //levelLoader.GetComponent<LevelLoader>().LoadNextLevel("Cantina");
        }
    }


    public void Update()
    {
        //Set hero variable
        hero = Hero.S;


        if (phaseCounter >= switchInt) //Using 60 fps update as the timer for switching fire states
        {
            if (Random.value<0.5) //50/50 whether vader will change weapons or not
            {
                if (!isFiring)
                {
                    SwitchWeapon();
                    if (isLaser)
                    {
                        weapon.GetComponent<Weapon>().fireRate = 0.3f;
                    }
                    else
                    {
                        weapon.GetComponent<Weapon>().fireRate = 1.2f;
                    }
                }

            }
            isFiring = !isFiring; //Simple flipflop between states
            switchInt = Random.Range(240  , 600); //Randomness between how often he rests/fires for, 4-10 seconds of each phase
            phaseCounter = 0; //Reset counter for how long next phase is

           

        }



        //Attack if in range
        if (isFiring) //Only attack if time to fire
        {
            if (heroInRange(detectionRange))
            {
                Attack();
            }
        }

        //if colliding with a projectile, make the enemy take damage

        //if the enemy is not current in a trigger zone, walk left

        //if the enemy is in a trigger zone walk right

        //finally make the enemy move in which ever direction
        EnemyMove();
        UpdateText();
        phaseCounter++;
    }

    public void SwitchWeapon()
    {
        if (!isLaser)
        {
            EquipWeapon(weapons[0]);
        }
        else
        {
            EquipWeapon(weapons[1]);
        }
        isLaser = !isLaser;
    }


    IEnumerator HalfHealth()
    {
        halfHealthText.SetActive(true);
        yield return new WaitForSeconds(5f);
        halfHealthText.SetActive(false);
    }

    IEnumerator FullHealth()
    {
        introText.SetActive(true);
        yield return new WaitForSeconds(5f);
        introText.SetActive(false);

    }

   

    public void UpdateText()
    {
        if (currentHealth == maxHealth && displayedOnce == 0)
        {
            StartCoroutine(FullHealth());
            displayedOnce++;
        }
        else if (currentHealth <= 100 && displayedOnce == 1)
        {
            StartCoroutine(HalfHealth());
            displayedOnce++;
        }
        else if (currentHealth <= 0) 
        {
            SaveSystem.ClearPlayer();
            levelLoader.GetComponent<LevelLoader>().LoadNextLevel("Exit Crawl");

        }
       
      
    }

}
