using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    public float walkSpeed;
    public int damage;
    public HealthBar healthBar;
    public bool isWalkingLeft = true;

    private Rigidbody2D e_Rigidbody2D;
    private Vector3 e_Velocity = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        e_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if colliding with a projectile, make the enemy take damage

        //if the enemy is not current in a trigger zone, walk left

        //if the enemy is in a trigger zone walk right

        //finally make the enemy move in which ever direction
        EnemyMove();
    }
        void LateUpdate() //Code to constantly check if player is dead
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }


    void OnTriggerEnter2D(Collider2D other) {

       isWalkingLeft = !isWalkingLeft;

        if(other.tag == "Laser")
        {
            TakeDamage(2);
            Destroy(other);
        }
        if(other.tag == "Grenade") {
            TakeDamage(1);
        }
        
    }
  

    void EnemyMove() {
        float move = 0f;
 
        if(isWalkingLeft) {
            move = -1*walkSpeed;
        } else {
            
            move = walkSpeed;
        }
		// Move the character by finding the target velocity
		Vector3 targetVelocity = new Vector2(move * 10f, 0f);
		// And then smoothing it out and applying it to the character
		e_Rigidbody2D.velocity = Vector3.SmoothDamp(e_Rigidbody2D.velocity, targetVelocity, ref e_Velocity, 0.05f);

        
		// If the input is moving the player right and the player is facing left...
		if (move > 0 && isWalkingLeft)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
		else if (move < 0 && !isWalkingLeft)
			{
				// ... flip the player.
				Flip();
			}
		
    }

    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		isWalkingLeft = !isWalkingLeft;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
