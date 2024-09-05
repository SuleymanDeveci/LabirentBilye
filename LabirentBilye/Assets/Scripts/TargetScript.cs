using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using labirentBilye.Managers;


public class TargetScript : MonoBehaviour
{

    public GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameManager.UnlockNextLevel();
        }
    }
}
