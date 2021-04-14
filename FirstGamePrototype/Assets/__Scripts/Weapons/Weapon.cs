using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected bool allowfire = true;
    protected float lastShot = 0;
    public float fireRate = 0.5f;
    public float attackSpeed;
    protected string attackerTag;
    protected float damageMultiplier;

    public virtual void Start()
    {
        attackerTag = transform.parent.parent.tag;
        damageMultiplier = transform.parent.parent.GetComponent<Entity>().damageMultiplier;
        
    }

    private void Update()
    {
        if (Time.time > fireRate + lastShot)
            allowfire = true;
        
        
    }

    protected void Reload()
    {
        allowfire = false;
        lastShot = Time.time;
       
    }

    //all weapons should be a child of the player object
    public abstract void Attack(GameObject target);
}
