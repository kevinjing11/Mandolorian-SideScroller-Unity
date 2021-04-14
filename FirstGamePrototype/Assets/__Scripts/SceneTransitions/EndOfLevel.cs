using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{

    //put the Level Loader object here
    public GameObject levelLoader;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //increase player level
            other.GetComponent<Hero>().IncreaseLevel();
            //save the player data
            other.GetComponent<Hero>().SavePlayer();
            //load the Cantina Scene
            levelLoader.GetComponent<LevelLoader>().LoadNextLevel("Cantina");
        }
       
    }
}
