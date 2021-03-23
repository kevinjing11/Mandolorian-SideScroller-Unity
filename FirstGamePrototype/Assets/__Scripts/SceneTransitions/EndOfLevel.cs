using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
    {
        //maybe add player progression here
        SceneManager.LoadScene("Cantina");
    }
}
