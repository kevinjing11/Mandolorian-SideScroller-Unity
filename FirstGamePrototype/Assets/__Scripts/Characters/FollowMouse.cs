using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public static Vector3 position;

    //Script to keep track of mouse position on the screen
    private void Start()
    {
        position = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = position;
    }
}
