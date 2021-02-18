using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
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
            weapon.GetComponent<OneClickRangedWeapon>().Attack();
        }
    }

    void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove, crouch, jump);
        jump = false;
    }
}
