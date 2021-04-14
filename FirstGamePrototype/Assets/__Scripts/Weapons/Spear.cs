using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Weapon
{

    public float thrustTime;
    private bool isThrusting = false;
    private Vector3 path;

    private float timeCount;

    public override void Start()
    {
        base.Start();
        PainPoint spearHead = transform.GetChild(0).GetComponent<PainPoint>();
        spearHead.attackerTag = attackerTag;
        
        spearHead.damageMultiplier = damageMultiplier;
    }
    public override void Attack(GameObject target)
    {
        if (!allowfire)
        {
            return;
        }
        else if(!isThrusting)
        {
            Debug.Log("Thrust");
            isThrusting = true;
            path = (target.transform.position - transform.position).normalized;
            timeCount = thrustTime;
            Reload();
        }
            
    }

    public void Update()
    {
        if (Time.time > fireRate + lastShot)
            allowfire = true;

        if (isThrusting)
            Thrust();
    }

    public void Thrust()
    {
        timeCount -= Time.deltaTime;

        if (timeCount > 0)
            transform.position += path * Time.deltaTime * attackSpeed;
        else if (timeCount > -thrustTime) // You don't want to move backwards too much!
            transform.position -= path * Time.deltaTime * attackSpeed;

        if (timeCount < -thrustTime)
            isThrusting = false;
    }

    public bool IsThrusting() { return isThrusting; }

}
