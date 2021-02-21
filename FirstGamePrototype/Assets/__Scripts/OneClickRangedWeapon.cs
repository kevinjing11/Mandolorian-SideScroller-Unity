using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneClickRangedWeapon : MonoBehaviour, RangedWeapon, Weapon
{
    public GameObject projectile;
    public float projectileSpeed;

    public void FireProjectile()
    {
        GameObject firedProjectile = Instantiate(projectile);
        firedProjectile.transform.position = transform.position;


        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float rotation = Mathf.Rad2Deg * Mathf.Atan((mousePosition.y - transform.position.y) / (mousePosition.x - transform.position.x));

        //for roation over 90 degrees
        if (rotation < 0)
            rotation = 180 + rotation;

        firedProjectile.transform.Rotate(0, 0, rotation);

        firedProjectile.GetComponent<Rigidbody2D>().velocity = (mousePosition - transform.position).normalized * projectileSpeed;
    }

    public void Attack()
    {
        FireProjectile();
    }
}
