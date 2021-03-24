using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleeWeapon : Weapon
{
    public GameObject damagePoint;

    private Vector3 path = Vector3.zero;
    private Vector3 distanceFromPlayer;
    
    public override void Attack()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        path = mousePosition - transform.position;
        distanceFromPlayer = transform.position - Hero.S.transform.position;
        moveOut();
       
        Invoke("moveBack", 1);
    }

    private void moveOut()
    {
        
        transform.position = transform.position + path.normalized * 1.5f;
    }

    private void moveBack()
    {
        transform.position = Hero.S.transform.position + distanceFromPlayer;
    }

}
