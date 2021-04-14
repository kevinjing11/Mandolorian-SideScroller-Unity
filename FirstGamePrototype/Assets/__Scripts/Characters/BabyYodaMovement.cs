using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyYodaMovement : MonoBehaviour
{
    public float amplitude = 0.01f;
    public float frequency = 1f;


    private float moveSpeed = 16;
    private float timeTravelled = 0;
    private float maxMoveTime = 0.1f;
    private bool isExtended = false;

    private float enduranceTime = 1;
    private float currentEndurance;

    private float coolDownTime = 2;
    private float currentCoolDown = 0;
    private float timeMultiplier = 1;
    

    //Position reference variables
    Vector2 tempPos = new Vector2();

    public void Start()
    {
        currentEndurance = enduranceTime;
    }

    // Update is called once per frame
    void Update()
    {
        //make object float up and down using sin function
        tempPos = transform.position;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;

        Debug.Log(currentEndurance);

        if (currentCoolDown > 0) 
        {
            currentCoolDown -= Time.deltaTime * timeMultiplier;
        }
            

        if (!isExtended && currentCoolDown <= 0 && currentEndurance < enduranceTime)
        {
            currentEndurance += Time.deltaTime * timeMultiplier * 3;
        }
        
    }

    public void Extend()
    {
        if(timeTravelled < maxMoveTime)
        {
            transform.localPosition = transform.localPosition + new Vector3(moveSpeed, -1.5f, 0) * Time.deltaTime;
            timeTravelled += Time.deltaTime * timeMultiplier;

            Vector3 scaleChange = new Vector3(0.007f, 0.007f, 0);
            gameObject.transform.localScale += scaleChange;
        }
        else
        {
            isExtended = true;
            currentCoolDown = coolDownTime;
        }

        if (currentEndurance > 0)
        {
            currentEndurance -= Time.deltaTime * timeMultiplier;
        }
            
        
    }

    public void Detract()
    {
        if(timeTravelled > 0)
        {
            transform.localPosition = transform.localPosition + new Vector3(-moveSpeed, 1.5f, 0) * Time.deltaTime;
            timeTravelled -= Time.deltaTime * timeMultiplier;

            Vector3 scaleChange = new Vector3(0.007f, 0.007f, 0);
            gameObject.transform.localScale -= scaleChange;
        }
        else
        {
            isExtended = false;
        }


    }

    public bool IsExtended() { return isExtended; }

    public bool HasEnergy() { return currentEndurance > 0; }

}
