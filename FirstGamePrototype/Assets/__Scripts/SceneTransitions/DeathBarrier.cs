using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Hero"){
            SceneManager.LoadScene("Cantina");
        } else {
            Destroy(other.gameObject);
        }
    }
}
