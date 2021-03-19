using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotator : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float rotation = Mathf.Rad2Deg * Mathf.Atan((mousePosition.y - transform.position.y) / (mousePosition.x - transform.position.x));

        
        transform.rotation = Quaternion.Euler(0f, 0f, rotation);

    }
}
