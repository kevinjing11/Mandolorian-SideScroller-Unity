using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleeWeapon : Weapon
{
    public GameObject damagePoint;

    private Vector3 path = Vector3.zero;
    private float attackSpeed = 1f;
    private int direction = 1;
    private Vector3 distanceFromPlayer;
    
    public override void Attack()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        path = mousePosition - transform.position;
        distanceFromPlayer = transform.position - Hero.S.transform.position;
        moveOut();
        //Invoke("changeDirection", 1);
        Invoke("moveBack", 1);
    }

    private void moveOut()
    {
        //direction = direction * -1;
        transform.position = transform.position + path.normalized * 1f;
    }

    private void moveBack()
    {
        transform.position = Hero.S.transform.position + distanceFromPlayer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = transform.position + (direction * path * attackSpeed * Time.deltaTime);
    }
}
