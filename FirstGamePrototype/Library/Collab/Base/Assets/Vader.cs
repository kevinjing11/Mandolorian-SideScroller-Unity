using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vader : Enemy
{
    public GameObject pointer;
    private GameObject currentWeapon;
    public GameObject missileLauncher;
    public GameObject laserGun;
    private int phaseCounter = 0;
    private int switchInt = 300;
    bool isFiring;
    bool enraged;

    //text objects
    public GameObject introText;
    public GameObject halfHealthText;
    public GameObject finalText;
    private int displayedOnce = 0;

    //level loader
    //put the Level Loader object here
    public GameObject levelLoader;


    public override void Start()
    {
        base.Start();
        introText.SetActive(false);
        halfHealthText.SetActive(false);
        finalText.SetActive(false);


    }

    private void StoreWeapon()
    {
        GameObject vader = this.gameObject;
        GameObject hand = vader.transform.GetChild(3).gameObject;
        GameObject weapon = hand.transform.GetChild(0).gameObject;
        Destroy(weapon);
    }

    public void LoadLaser()
    {
        StoreWeapon();
        EquipWeapon(laserGun);
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
        currentWeapon.GetComponent<ArmRotator>().pointer = player;
    }

    public void LateUpdate() //Code to constantly check if player is dead
    {
        if(currentHealth <= 100) //half of maxHealth
          
        {
            if (!enraged)
            {
                //
                runSpeed += 0.3f;
                weapon.GetComponent<Weapon>().fireRate -= 0.2f;

                if(Hero.S.gameObject.transform.position.x >= gameObject.transform.position.x) //If enraged while player is to the right
                {
                    gameObject.transform.localScale = new Vector3(3.5f, 3.5f, 2.96f);
                }
                else
                {
                    gameObject.transform.localScale = new Vector3(-3.5f, 3.5f, 2.96f);
                }

                LoadLaser();
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
            isFiring = !isFiring; //Simple flipflop between states
            switchInt = Random.Range(120, 420); //Randomness between how often he rests/fires for, 2-7 seconds of each phase
            phaseCounter = 0; //Reset counter for how long next ophase is
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

    IEnumerator Death()
    {
        finalText.SetActive(true);
        yield return new WaitForSeconds(5f);
      
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
        else if (currentHealth == 0) 
        {
            StartCoroutine(Death());
            //load the Cantina Scene
            levelLoader.GetComponent<LevelLoader>().LoadNextLevel("Exit Crawl");
        }
       
      
    }

}
