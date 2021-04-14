using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int coins;
    public float level;
    public int maxHealth;
    public float damageMultiplier;
    public float knockBackResitance;
    public float runSpeed;
    

    public PlayerData(Hero player)
    {
        level = player.level;
        coins = player.currentCoins;
        maxHealth = player.maxHealth;
        damageMultiplier = player.damageMultiplier;
        knockBackResitance = player.knockBackResitance;
        runSpeed = player.runSpeed;

    }
    public void ResetToMinLevel()
    {
        Hero.S.knockBackResitance = 1f;
        Hero.S.maxHealth = 20;
        Hero.S.damageMultiplier = 1f;
        Hero.S.runSpeed = 1f;
        Hero.S.level = 0f;
        Hero.S.currentCoins = 0;
    }   
}
