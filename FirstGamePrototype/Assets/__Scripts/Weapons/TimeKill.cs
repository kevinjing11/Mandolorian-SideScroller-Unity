using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKill : MonoBehaviour
{
    private float timeAlive = 0;
    public float maxTime = 5;
    private void Update()
    {
        timeAlive += Time.deltaTime;


        if (timeAlive > maxTime)
            Destroy(gameObject);
    }

}
