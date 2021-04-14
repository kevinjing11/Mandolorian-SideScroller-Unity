using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; //For textmesh updating

public class Hero : Entity
{
    public bool jumpRestriction = false;
    public CharacterController2D controller;
    public Animator animator; //Define animator object to be used for animations
   
    

    static public Hero S;
    public float level = 0;

    private bool jump = false;
    private bool crouch = false;
    private float horizontalMove = 0f;

    public BabyYoda babyYoda;

   
    public int currentCoins; //For counting current number of coins the hero has
    public TextMeshProUGUI coinsText;

    public PauseMenu pauseMenu;

    //private bool noWeapon = false;

    //override equip weapon method
    public override void EquipWeapon(GameObject newWeapon)
    {
        base.EquipWeapon(newWeapon);
        newWeapon.GetComponent<ArmRotator>().pointer = transform.GetChild(5).gameObject;

    }

    // methods for saving player data, coins, health, etc.
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayerStep1()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        base.maxHealth = data.maxHealth;
        base.damageMultiplier = data.damageMultiplier;
        base.damageMultiplier = data.damageMultiplier;
        base.knockBackResitance = data.knockBackResitance;
        base.runSpeed = data.runSpeed;
    }

    public void LoadPlayerStep2()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        currentCoins = data.coins;
    }

    public override void Start()
    {
        LoadPlayerStep1(); //load saved player attributes
        base.Start();

        if (S == null) S = this; //set singleton
        LoadPlayerStep2();
        
        coinsText.SetText(currentCoins.ToString());
    }

  
    // Update is called once per frame
    void Update()
    {
        if(!pauseMenu.GameIsPaused) {
            GetInput(); //make sure not to move when game is paused
        }
        coinsText.SetText(currentCoins.ToString());
    }

    public void addCoins(int v) //add to current coins the amount that an enemy awards
    {
        currentCoins += v;
    }
    public int getCoins()
    {
        return currentCoins;
    }

    public bool subtractCoins(int price)
    {
        if (currentCoins >= price)
        {
            currentCoins -= price;
            return true;
        }

        return false;
    }

    //method to take input from player
    private void GetInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        if(!jumpRestriction)
            {
            if (Input.GetButtonDown("Jump"))
                {
                    jump = true;
                    animator.SetBool("IsJumping", true);
                }
            }
      
        //attack listenor
        if (Input.GetMouseButtonDown(0))
            {
                weapon.GetComponent<Weapon>().Attack(transform.GetChild(5).gameObject);
            }

        //shift key to make yoda go into shield state
        if (Input.GetKey(KeyCode.LeftShift) && babyYoda.HasEnergy())
        {

            babyYoda.MoveForward();
        }
        else
        {
            babyYoda.MoveBack();
        }

    }


    
    void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove, crouch, jump);
        jump = false;
    }

    public void OnLanding() //public component to be fed into animator for jump control
    {
      
            animator.SetBool("IsJumping", false); 
    }

    void LateUpdate() //Code to constantly check if player is dead
    {
        CheckIfDead();
    }

    void CheckIfDead()
    {
        if (currentHealth <= 0)
        {
            SavePlayer();
            SceneManager.LoadScene("Cantina");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin") //handle coin collision
        {
            Destroy(collision.gameObject); //Destroy the coin
            currentCoins++; //Add one to player count

        }
        if (collision.tag == "Bitcoin") //handle coin collision
        {
            Destroy(collision.gameObject); //Destroy the coin
            currentCoins+= 50000; //Add current value of bitcoin

        }
        if (collision.tag == "HeartPack") //handle coin collision
        {
            Destroy(collision.gameObject); //Destroy the coin
            healthBar.SetHealth(maxHealth);
             //Add current value of bitcoin

        }
    }

    //setters and getters

    public double getCurrentPlayerLevel()
    {
        return level;
    }
    public void IncreaseLevel()
    {
        //has to go up by 0.5 because onTrigger double calls
        level = level + 0.5f;
    }

    public void IncreaseDamage()
    {
        damageMultiplier += 0.1f;
    }

    public double getDamage()
    {
        return damageMultiplier;
    }

    public void IncreaseHealth()
    {
        maxHealth += 5;
    }

    public int getMaxHealth()
    {
        return maxHealth; 
    }

    public void IncreaseSpeed()
    {
        runSpeed += 0.1f;
    }

    public double getSpeed()
    {
       return runSpeed;
    }
}
