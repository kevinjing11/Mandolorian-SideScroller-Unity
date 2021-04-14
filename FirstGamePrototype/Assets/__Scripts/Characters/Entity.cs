using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public GameObject weapon;

    //entity attributes
    public float knockBackResitance = 1;
    public int maxHealth = 20;
    public float damageMultiplier = 1;
    public float runSpeed = 1;
    public HealthBar healthBar;
    public bool isWalkingLeft = true;

    //health count
    protected int currentHealth;

    //method to make character take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public virtual void Start()
    {
        //set health to max
        currentHealth = maxHealth;

        //set healthbar
        healthBar.SetMaxHealth(maxHealth);
    }

    protected void Flip()
    {
        // Switch the way the player is labelled as facing.
        isWalkingLeft = !isWalkingLeft;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public virtual void EquipWeapon(GameObject newWeapon)
    {
        //Destroy currently equip weapon
        Destroy(weapon);

        //Make sure player is facing left
        bool wasFlipped = false;
        if (!isWalkingLeft)
        {
            Flip();
            wasFlipped = true;
        }
            

        //get holster of weapon
        GameObject hand = this.gameObject.transform.GetChild(0).gameObject;

        //create 
        weapon = Instantiate(newWeapon);

        //set as child of hand
        weapon.transform.parent = hand.transform;
        weapon.transform.position = hand.transform.position;
        weapon.transform.rotation = hand.transform.rotation;

        if (wasFlipped)
            Flip();

    }
}
