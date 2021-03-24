using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    
    //all weapons should be a child of the player object
    public abstract void Attack();
}
