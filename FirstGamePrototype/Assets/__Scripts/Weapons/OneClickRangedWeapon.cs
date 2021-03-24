using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneClickRangedWeapon : Weapon
{
    public GameObject projectile;
    public float projectileSpeed;
    public GameObject firePoint;
    override public void Attack()
    {
        GameObject firedProjectile = Instantiate(projectile);
        firedProjectile.transform.position = firePoint.transform.position;


        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float rotation = Mathf.Rad2Deg * Mathf.Atan((mousePosition.y - firePoint.transform.position.y) / (mousePosition.x - firePoint.transform.position.x));

        //for roation over 90 degrees
        if (rotation < 0)
            rotation = 180 + rotation;

        firedProjectile.transform.Rotate(0, 0, rotation);

        firedProjectile.GetComponent<Rigidbody2D>().velocity = (mousePosition - firePoint.transform.position).normalized * projectileSpeed;
    }

    
}
