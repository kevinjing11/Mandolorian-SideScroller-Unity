using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopButtons : MonoBehaviour
{
    public Text damage;
    public Text health;
    public Text speed;

    static int damageUpgradeCost = 5;
    static int healthUpgradeCost = 5;
    static int speedUpgradeCost= 5;

    public TextMeshProUGUI damageCoinsText;
    public TextMeshProUGUI healthCoinsText;
    public TextMeshProUGUI speedCoinsText; //Defining textmeshpro objects so coin upgrade cost can be updated and displayed

    public GameObject player;

    void Start()
    {
       
        damage.text = player.GetComponent<Hero>().getDamage();
        health.text = player.GetComponent<Hero>().getMaxHealth();
        speed.text = player.GetComponent<Hero>().getSpeed();

        damageCoinsText.SetText(damageUpgradeCost.ToString());
        healthCoinsText.SetText(healthUpgradeCost.ToString());
        speedCoinsText.SetText(speedUpgradeCost.ToString());//initiate to their current values
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
            damage.text = player.GetComponent<Hero>().getDamage();

            damageUpgradeCost = (int) Mathf.RoundToInt((float)(damageUpgradeCost * 1.5)); //Damage upgrade cost increases exponentially to not allow abusing upgrades
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
            health.text = player.GetComponent<Hero>().getMaxHealth();

            healthUpgradeCost = (int)Mathf.RoundToInt((float)(healthUpgradeCost * 1.5)); //Speed upgrade cost increases exponentially to not allow abusing upgrades
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
            speed.text = player.GetComponent<Hero>().getSpeed();

            speedUpgradeCost = (int)Mathf.RoundToInt((float)(speedUpgradeCost * 1.5)); //Speed upgrade cost increases exponentially to not allow abusing upgrades
            speedCoinsText.SetText(speedUpgradeCost.ToString());
        }
    }
}
