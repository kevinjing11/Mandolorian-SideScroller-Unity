﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : Enemy
{

    public int _moveSpeed;
    public int _attackDamage;
    public  int _lifePoints;
    public float _attackRadius;

        //movement
    public float _followRadius;

    [SerializeField] Transform playerTransform;
    //[SerializeField]Animator enemyAnim;
    SpriteRenderer enemySR;


    // Start is called before the first frame update
    void Start()
    {
         playerTransform = FindObjectOfType<Hero>().GetComponent<Transform>();
         //enemyAnim = gameObject.GetComponent<Animator>();
         enemySR = GetComponent<SpriteRenderer>();

        //set the variables
        setMoveSpeed(_moveSpeed);
        setAttackDamage(_attackDamage);
        setLifePoints(_lifePoints);
        setAttackRadius(_attackRadius);
        setFollowRadius(_followRadius);
   
    }

    // Update is called once per frame
    void Update()
    {
        
        if (checkFollowRadius(playerTransform.position.x,transform.position.x))
        {
            //if player in front of the enemies
            if (playerTransform.position.x < transform.position.x)
            {

                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    //for attack animation
                    //enemyAnim.SetBool("AttackA", true);
                }
                else
                {
                    this.transform.position += new Vector3(-getMoveSpeed() * Time.deltaTime, 0f, 0f);
                    //for attack animation
                   // enemyAnim.SetBool("AttackA", false);
                    //walk
                   // enemyAnim.SetBool("Walking", true);
                    enemySR.flipX = true;
                }

            }
            //if player is behind enemies
            else if(playerTransform.position.x > transform.position.x)
            {
                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    //for attack animation
                    //enemyAnim.SetBool("AttackA", true);
                }
                else
                {
                    this.transform.position += new Vector3(getMoveSpeed() * Time.deltaTime, 0f, 0f);
                    //for attack animation
                    //enemyAnim.SetBool("AttackA", false);
                    //walk
                    //enemyAnim.SetBool("Walking", true);
                    enemySR.flipX = false;
                }


            }
        }
        else
        {
            //enemyAnim.SetBool("Walking", false);
        }


    }
}
