using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Weapon
{

    //all weapons should be a child of the player object
    void Attack();
}
