﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float timeAlive = 0;
    private void Update()
    {
        timeAlive += Time.deltaTime;

        Debug.Log(timeAlive);

        if (timeAlive > 5)
            Destroy(gameObject);
    }

}