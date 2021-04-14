using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyYoda : MonoBehaviour
{
    //attribute to keep track of floating animation
    public float amplitude = 0.01f;
    public float frequency = 1f;

    //attributes to control movement
    private float moveSpeed = 16;
    private float timeTravelled = 0;
    private float maxMoveTime = 0.1f;
    private bool isExtended = false;

    //attrubutes to control enderance/block time and cool down
    private float enduranceTime = 1;
    private float currentEndurance;
    private float coolDownTime = 2;
    private float currentCoolDown = 0;
    private float timeMultiplier = 1;

    //mana bar to display energy levels
    public HealthBar manaBar;

    //Position reference variables
    Vector2 tempPos = new Vector2();

    public void Start()
    {
        //set energy to max energy
        currentEndurance = enduranceTime;
    }

    // Update is called once per frame
    void Update()
    {
        //make object float up and down using sin function
        tempPos = transform.position;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;

        
        //count down cool down time
        if (currentCoolDown > 0) 
        {
            currentCoolDown -= Time.deltaTime * timeMultiplier;
        }
            
        //if yoda is not extended and cool down has counted down and endurance is not at a maximum
        //then increase energy levels
        if (!isExtended && currentCoolDown <= 0 && currentEndurance < enduranceTime)
        {
            currentEndurance += Time.deltaTime * timeMultiplier * 3;
        }

        //update manabar display
        manaBar.SetHealth(Mathf.FloorToInt(currentEndurance*100));// Multiply currentendurance by factor to be convertable to int
    }

    public void MoveForward()
    {
        //check whether yoda has moved his max amount of time
        if(timeTravelled < maxMoveTime)
        {
            //move yoda forward
            transform.localPosition = transform.localPosition + new Vector3(moveSpeed, -1.5f, 0) * Time.deltaTime;
            timeTravelled += Time.deltaTime * timeMultiplier;

            //make yoda bigger
            Vector3 scaleChange = new Vector3(0.007f, 0.007f, 0);
            gameObject.transform.localScale += scaleChange;
        }
        else
        {
            //set cool down time to max
            isExtended = true;
            currentCoolDown = coolDownTime;
        }

        //decrease endurance
        if (currentEndurance > 0)
        {
            currentEndurance -= Time.deltaTime * timeMultiplier;
        }
            
        
    }

    public void MoveBack()
    {
        //check if time travelled is zero
        if(timeTravelled > 0)
        {
            //move yoda back
            transform.localPosition = transform.localPosition + new Vector3(-moveSpeed, 1.5f, 0) * Time.deltaTime;
            timeTravelled -= Time.deltaTime * timeMultiplier;

            //make yoda small
            Vector3 scaleChange = new Vector3(0.007f, 0.007f, 0);
            gameObject.transform.localScale -= scaleChange;
        }
        else
        {
            isExtended = false;
        }


    }

    //getter for isExtended
    public bool IsExtended() { return isExtended; }

    //check whether energy is zero
    public bool HasEnergy() { return currentEndurance > 0; }

}
