using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedExplode : MonoBehaviour
{
    private float timeAlive = 0;
    public float maxTime = 3;
    public Sprite explosionSprite;

    private Vector3 scaleChange = Vector3.zero;

    private void Update()
    {
        timeAlive += Time.deltaTime;


        if (timeAlive > maxTime)
            Explode();

        if (timeAlive > maxTime + 2)
            Destroy(gameObject);

    }

    private void Explode()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = explosionSprite;
        scaleChange = new Vector3(0.007f, 0.007f, 0);
        gameObject.transform.localScale += scaleChange;
    }
    
    
}
