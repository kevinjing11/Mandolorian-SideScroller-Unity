using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrigger : MonoBehaviour
{
    public int requiredPlayerLevel;
    public GameObject uiElement;

    // Start is called before the first frame update
    void Start()
    {
         uiElement.SetActive(false);
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.GetComponent<Hero>().getCurrentPlayerLevel() >= requiredPlayerLevel)
        {
            //make UI appear
            uiElement.SetActive(true);

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        //make UI disappear
        uiElement.SetActive(false);

    }
}
