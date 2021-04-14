using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    public string nextScene = "Cantina";
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") {
            Hero s = other.GetComponent<Hero>();
            s.SavePlayer();
            SceneManager.LoadScene(nextScene);
        }
    }
}
