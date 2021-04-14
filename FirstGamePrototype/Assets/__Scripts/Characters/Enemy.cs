using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    //enemy attrivutes
    public int coinReward;
    public float detectionRange;
    public float attackRange;
    protected Hero hero;

    private Rigidbody2D e_Rigidbody2D;
    private Vector3 e_Velocity = Vector3.zero;

    public void EnemyMove()
    {
        //Set pointer on player
        weapon.GetComponent<ArmRotator>().pointer = hero.gameObject;

        //Make sure they face the player
        if (isWalkingLeft && hero.transform.position.x < transform.position.x)
            Flip();

        if (!isWalkingLeft && hero.transform.position.x > transform.position.x)
            Flip();

        //move to firing distance


        //check if enemy is in firing range
        float distance = (hero.transform.position - transform.position).magnitude;

        if (distance > attackRange - 1 && distance < attackRange)
            return;

        //move enemy into firing range
        if (heroInRange(attackRange - 1))
        {
            if (hero.transform.position.x < transform.position.x)
                Move(1);
            else
                Move(-1);

        }
        else if (heroInRange(detectionRange))
        {
            if (hero.transform.position.x < transform.position.x)
                Move(-1);
            else
                Move(1);
        }
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        e_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set hero variable
        hero = Hero.S;

        //move the enemy
        EnemyMove();

        //Attack if in range
        if (heroInRange(attackRange))
        {
            Attack();
        }
       
            
    }
    void LateUpdate() //Code to constantly check if player is dead
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            hero.addCoins(coinReward);
        }
    }


    protected void Move(int xDirection)
    {
        float move = xDirection * runSpeed;

        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, 0f);
        // And then smoothing it out and applying it to the character
        e_Rigidbody2D.velocity = Vector3.SmoothDamp(e_Rigidbody2D.velocity, targetVelocity, ref e_Velocity, 0.05f);

    }

   
    //check wether hero is whithin a radius from the enemy
    protected bool heroInRange(float radius)
    {
        return (hero.transform.position - transform.position).magnitude < radius;
    }

    //call the weapon object to attack
    public void Attack()
    {
        weapon.GetComponent<Weapon>().Attack(hero.gameObject);
    }

}
