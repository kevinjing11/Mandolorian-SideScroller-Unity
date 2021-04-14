using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //put the Level Loader object here
    public GameObject levelLoader;
    public GameObject mando;

    public string nextLevel;


  
    public void PlayGame()
    {
        //find the funciton in the script LevelLoader to initalize the transition and load the next level
        levelLoader.GetComponent<LevelLoader>().StartGame(nextLevel);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Pushed");
        Application.Quit();
    }

    public void SkipButton()
    {
        //find the funciton in the script LevelLoader to initalize the transition and load the next level
        levelLoader.GetComponent<LevelLoader>().StartGame(nextLevel);
    }

}
