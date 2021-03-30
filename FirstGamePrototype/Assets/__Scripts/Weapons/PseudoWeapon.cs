using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoWeapon : Weapon
{

    int i = 0;
    // Start is called before the first frame update
    public override void Attack()
    {
        i++;
    }
}
