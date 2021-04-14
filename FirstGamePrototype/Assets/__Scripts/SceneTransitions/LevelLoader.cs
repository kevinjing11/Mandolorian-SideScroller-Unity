using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Hero player;

    public Animator transition;

    public float transitionTime = 1f;

    public void StartGame(string nextLevelName)
    {
      StartCoroutine(LoadLevel(nextLevelName));
    }
 
    public void LoadNextLevel(string nextLevelName)
    {
        //co routine
        StartCoroutine(LoadLevel(nextLevelName));

        player.SavePlayer();

      
    }

    IEnumerator LoadLevel(string levelName)
    {
        //Play our animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load Scene
        SceneManager.LoadScene(levelName);
    }
}
