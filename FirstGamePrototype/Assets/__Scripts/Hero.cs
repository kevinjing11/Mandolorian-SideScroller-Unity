﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator; //Define animator object to be used for animations
    public float runSpeed = 40f;
    public GameObject weapon;

    static public Hero S;

    private bool jump = false;
    private bool crouch = false;
    private float horizontalMove = 0f;

    private void Start()
    {
        if (S == null) S = this;
    }

  
    // Update is called once per frame
    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            weapon.GetComponent<WeaponAttack>().Attack();
        }
        
    }

    void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove, crouch, jump);
        jump = false;
    }

    public void OnLanding() //public component to be fed into animator for jump control
    {
      
            animator.SetBool("IsJumping", false); 
    }

}
