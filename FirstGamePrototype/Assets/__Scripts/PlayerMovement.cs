using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    public GameObject weapon;

    private bool jump = false;
    private bool crouch = false;
    private float horizontalMove = 0f;


    // Update is called once per frame
    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

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

       

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    public void OnLanding() //Needed for jump transitions
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove, crouch, jump);
        jump = false;
    }
}
