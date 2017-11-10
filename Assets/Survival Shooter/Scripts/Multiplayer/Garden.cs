using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Garden : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        //If enemy touches the garden
        if (other.transform.tag == "Enemy")
        {
            // The game ends
            SceneManager.LoadScene(2);
        }
    }
}
