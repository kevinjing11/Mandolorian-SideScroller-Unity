using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopButtons : MonoBehaviour
{
    public Text damage;
    public Text health;
    public Text speed;

    public GameObject player;

    void Start()
    {
       
        damage.text = player.GetComponent<Hero>().getDamage();
        health.text = player.GetComponent<Hero>().getMaxHealth();
        speed.text = player.GetComponent<Hero>().getSpeed();
    }

    // Start is called before the first frame update
    public void damageUpgrade()
    {
        //subtract player coins
        if (player.GetComponent<Hero>().subtractCoins(5))
        {
            //update stats
            player.GetComponent<Hero>().IncreaseDamage();

            //update UI
            damage.text = player.GetComponent<Hero>().getDamage();
        }
       
    }

    // Update is called once per frame
    public void healthUpgrade()
    {
        //subtract player coins
        if (player.GetComponent<Hero>().subtractCoins(5))
        {
            //update stats
            player.GetComponent<Hero>().IncreaseHealth();

            //update UI
            damage.text = player.GetComponent<Hero>().getMaxHealth();
        }
    }

    public void speedUpgrade()
    {
        //subtract player coins
        if (player.GetComponent<Hero>().subtractCoins(5))
        {
            //update stats
            player.GetComponent<Hero>().IncreaseSpeed();

            //update UI
            damage.text = player.GetComponent<Hero>().getSpeed();
        }
    }
}
