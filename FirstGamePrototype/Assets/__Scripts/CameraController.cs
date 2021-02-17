using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script that makes camera follow the player
public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public float xLowerBound;
    public float xUpperBound;
    public float yLowerBound;
    public float yUpperBound;

    float height;
    float width;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = gameObject.GetComponent<Camera>();
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;

        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if(player.transform.position.x > xLowerBound + width/2 && player.transform.position.x < xUpperBound - width/2)
            transform.position = new Vector3(offset.x + player.transform.position.x, transform.position.y, -10);

    }

    private bool InBounds()
    {
        if (player.transform.position.x < xLowerBound 
            || player.transform.position.x > xUpperBound 
            || player.transform.position.y < yLowerBound
            || player.transform.position.y > yUpperBound
            )
            return false;

        return true;
    }
}