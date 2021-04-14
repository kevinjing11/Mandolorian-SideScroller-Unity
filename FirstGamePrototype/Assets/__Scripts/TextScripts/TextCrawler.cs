using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TextCrawler : MonoBehaviour
{
    //put the Level Loader object here
    public GameObject levelLoader;

    public string nextLevel;



    //variable that controls the scroll speed
    public float scrollSpeed = 20;

    public float time;

    public Animator transition;

    private void Start()
    {
        //co routine
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
     
     //Wait
     yield return new WaitForSeconds(time);

     levelLoader.GetComponent<LevelLoader>().LoadNextLevel(nextLevel);


    }



    // Update is called once per frame
    void Update()
    {
        //get current position of the GameObject
        Vector3 pos = transform.position;

        // get the vector pointing into the direction
        Vector3 localVectorUp = transform.TransformDirection(0, 1, 0);

        //move the text object into the distance with the scrolling effect
        pos += localVectorUp * scrollSpeed * Time.deltaTime;
        transform.position = pos;
    }


}

