﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public Weapon weapon;
    public void Attack()
    {
        weapon.Attack();
    }
}
