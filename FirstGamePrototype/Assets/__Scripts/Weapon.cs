using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public GameObject firePoint;
    //all weapons should be a child of the player object
    public abstract void Attack();
}
