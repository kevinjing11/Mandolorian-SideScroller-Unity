using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyYodaMovement : MonoBehaviour
{
    public float amplitude = 0.01f;
    public float frequency = 1f;

    //Position reference variables
    Vector2 tempPos = new Vector2();
 

    // Update is called once per frame
    void Update()
    {
        //make object float up and down using sin function
        tempPos = transform.position;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }
}
