using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : PainPoint
{
    public float maxTime = 5;

    protected float timeAlive = 0;

    private void Update()
    {
        timeAlive += Time.deltaTime;


        if (timeAlive > maxTime)
            Kill();
    }
    
    public override void Kill()
    {
        Destroy(gameObject);
    }
}
