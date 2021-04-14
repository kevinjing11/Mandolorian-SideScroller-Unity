using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopData
{

    public int damageUpgradeCost = 50;
    public int healthUpgradeCost = 50;
    public int speedUpgradeCost= 50;
    

    public ShopData(ShopButtons shop)
    {
        damageUpgradeCost = shop.damageUpgradeCost;
        healthUpgradeCost = shop.healthUpgradeCost;
        speedUpgradeCost = shop.speedUpgradeCost;
    }
    public void ResetToMinValue(ShopButtons shop)
    {
        damageUpgradeCost = 50;
        healthUpgradeCost = 50;
        speedUpgradeCost = 50;

        shop.LoadShop();
    } 
}
