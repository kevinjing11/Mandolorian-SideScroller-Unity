using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneClickRangedWeapon : Weapon
{
    public GameObject projectile;
    public GameObject firePoint;


    override public void Attack(GameObject target) //script for attacking with a ranged weapon
    {
        if (!allowfire)
        {
            return;
        }
        

        GameObject firedProjectile = Instantiate(projectile); //create new projectile of the weapon that will go towards fired point
        firedProjectile.transform.position = firePoint.transform.position;

        Vector3 targetPosition = target.transform.position;

        float rotation = Mathf.Rad2Deg * Mathf.Atan((targetPosition.y - firePoint.transform.position.y) / (targetPosition.x - firePoint.transform.position.x));

        //for roation over 90 degrees
        if (rotation < 0)
            rotation = 180 + rotation;

        firedProjectile.transform.Rotate(0, 0, rotation);
        
        firedProjectile.GetComponent<Rigidbody2D>().velocity = (targetPosition - firePoint.transform.position).normalized * attackSpeed;

        Projectile proj = firedProjectile.transform.GetComponent<Projectile>();

        proj.attackerTag = attackerTag;

        proj.damageMultiplier = damageMultiplier;
        

        Reload();

        
    }

    
}
