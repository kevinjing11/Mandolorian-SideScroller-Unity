using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainPoint : MonoBehaviour
{
    public int damage = 4;
    public float knockBack = 1;
    public float damageMultiplier = 10;

    public string attackerTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject entityGameObject = other.gameObject;

        if (other.tag == "Player" && attackerTag == "Enemy")
            MakeContact(entityGameObject);

        else if (other.tag == "Enemy" && attackerTag == "Player")
            MakeContact(entityGameObject);

        else if (other.tag == "Yoda")
        {
            if (entityGameObject.GetComponent<BabyYoda>().IsExtended())
            {
                GetComponent<Rigidbody2D>().velocity *= -1;
                attackerTag = "Player";
            }
            
        }
            

    }

    public virtual void Kill() { }

    public virtual Vector2 Knockback(GameObject bluntedObject)
    {
        float xdirection = (bluntedObject.transform.position.x < transform.position.x) ? -1 : 1;
        float knockBackResistance = bluntedObject.GetComponent<Entity>().knockBackResitance;
        return new Vector2(xdirection * knockBack * knockBackResistance, xdirection * knockBack * knockBackResistance);

    }

    private void MakeContact(GameObject entityGameObject)
    {
        //Kill gameobject
        Kill();

        Entity entity = entityGameObject.GetComponent<Entity>();
        
        //Make entity take damage
        entity.TakeDamage(Mathf.RoundToInt(damage * damageMultiplier));

        //Knockback entity
        Rigidbody2D entityRB = entityGameObject.GetComponent<Rigidbody2D>();
        entityRB.velocity = Knockback(entityGameObject);
        
    }
}
