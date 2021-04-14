using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Projectile
{
    public Sprite explosionSprite;

    //overriden method of kill to make projectile explode
    public override void Kill()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = explosionSprite;
        Vector3 scaleChange = new Vector3(0.007f, 0.007f, 0);
        gameObject.transform.localScale += scaleChange; //Bomb explosion grows by a factor of this

        if (timeAlive > maxTime + 2)
            base.Kill();
    }

    public override Vector2 Knockback(GameObject bluntedObject) //Does knockback to gameObject hit
    {
        float magnitude = base.Knockback(bluntedObject).magnitude;
        return new Vector2(magnitude, magnitude);
    }


}
