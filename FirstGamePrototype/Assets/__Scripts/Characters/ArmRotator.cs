using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pointer;

    //boolean to keep track of on/off
    public bool point = true;

    // Update is called once per frame
    void Update()
    {
        if (point)
        {
            //calculate rotation
            Vector3 target = pointer.transform.position; 
            float rotation = Mathf.Rad2Deg * Mathf.Atan((target.y - transform.position.y) / (target.x - transform.position.x));
            transform.rotation = Quaternion.Euler(0f, 0f, rotation);
        }
        

    }
}
