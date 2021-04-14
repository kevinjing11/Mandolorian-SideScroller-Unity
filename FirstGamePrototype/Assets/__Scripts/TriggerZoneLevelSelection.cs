using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerZoneLevelSelection : MonoBehaviour
{
    //put the Level Loader object here
    public GameObject levelLoader;
    public string nextLevel;
    public int requiredPlayerLevel;

    public bool displayOnce = false;
    static private int displayed = 0;

    //UI
    public GameObject uiElement;
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void Start()
    {
        uiElement.SetActive(false);
       
    }

    private void Update()
    {
        if(uiElement.activeSelf == true)
        {
            //button press
            if (Input.GetKeyDown(KeyCode.E))
            {
                levelLoader.GetComponent<LevelLoader>().LoadNextLevel(nextLevel);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && other.GetComponent<Hero>().getCurrentPlayerLevel() >= requiredPlayerLevel)
        {
            //make UI appear
            if (!displayOnce)
            {
                uiElement.SetActive(true);
                TriggerDialogue();
            } else if (displayOnce && displayed == 0){
                uiElement.SetActive(true);
                TriggerDialogue();
                displayed++;
            }
           
        }
       


    }

   void OnTriggerExit2D(Collider2D other)
    {
        
        // make UI disappear
        uiElement.SetActive(false);
       
        
           
        
    }

}
