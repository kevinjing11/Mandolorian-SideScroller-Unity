using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class ShopButtons : MonoBehaviour
{
    public Text damage;
    public Text health;
    public Text speed; //Variables for text of the attributes to be upgraded

    public int damageUpgradeCost;
    public int healthUpgradeCost;
    public int speedUpgradeCost; //Saved integers that scale with each upgrade

    public TextMeshProUGUI damageCoinsText;
    public TextMeshProUGUI healthCoinsText;
    public TextMeshProUGUI speedCoinsText; //Defining textmeshpro objects so coin upgrade cost can be updated and displayed

    public GameObject player;
   

    void Start()
    {
       
        damage.text = (player.GetComponent<Hero>().getDamage()).ToString();
        health.text = (player.GetComponent<Hero>().getMaxHealth()).ToString();
        speed.text = (player.GetComponent<Hero>().getSpeed()).ToString();


        damageUpgradeCost = (int)((player.GetComponent<Hero>().getDamage() + 1) * 40);
        damageCoinsText.SetText(damageUpgradeCost.ToString());

        healthUpgradeCost = player.GetComponent<Hero>().getMaxHealth() * 5;
        healthCoinsText.SetText(healthUpgradeCost.ToString());

        speedUpgradeCost = (int)((player.GetComponent<Hero>().getSpeed() + 1) * 40);
        speedCoinsText.SetText(speedUpgradeCost.ToString());//initiate to their current values
    }

    public void LoadShop()
    {
        ShopData data = SaveSystem.LoadShop();
        damageUpgradeCost = data.damageUpgradeCost;
        healthUpgradeCost = data.healthUpgradeCost;
        speedUpgradeCost = data.speedUpgradeCost;
    }

    // Start is called before the first frame update
    public void damageUpgrade()
    {
        //subtract player coins
        if (player.GetComponent<Hero>().subtractCoins(damageUpgradeCost))
        {
            //update stats
            player.GetComponent<Hero>().IncreaseDamage();

            //update UI
            damage.text = (player.GetComponent<Hero>().getDamage()).ToString();

            damageUpgradeCost = (int)((player.GetComponent<Hero>().getDamage() + 1) * 50);
           //Damage upgrade cost increases exponentially to not allow abusing upgrades

            damageCoinsText.SetText(damageUpgradeCost.ToString());
        }
       
    }

    // Update is called once per frame
    public void healthUpgrade()
    {
        //subtract player coins
        if (player.GetComponent<Hero>().subtractCoins(healthUpgradeCost))
        {
            //update stats
            player.GetComponent<Hero>().IncreaseHealth();

            //update UI
            health.text = (player.GetComponent<Hero>().getMaxHealth()).ToString();

            healthUpgradeCost = player.GetComponent<Hero>().getMaxHealth() * 5;
            //Speed upgrade cost increases exponentially to not allow abusing upgrades
            healthCoinsText.SetText(healthUpgradeCost.ToString());
            
        }
    }

    public void speedUpgrade()
    {
        //subtract player coins
        if (player.GetComponent<Hero>().subtractCoins(speedUpgradeCost))
        {
            //update stats
            player.GetComponent<Hero>().IncreaseSpeed();

            //update UI
            speed.text = (player.GetComponent<Hero>().getSpeed()).ToString();


            speedUpgradeCost = (int)((player.GetComponent<Hero>().getSpeed() + 1) * 40); //Speed upgrade cost increases exponentially to not allow abusing upgrades
            speedCoinsText.SetText(speedUpgradeCost.ToString());
        }
    }
}
