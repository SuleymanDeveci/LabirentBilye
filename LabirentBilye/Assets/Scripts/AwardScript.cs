using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardScript : MonoBehaviour
{
    [SerializeField] GameObject acilacakPanel;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            acilacakPanel.SetActive(true);
        }
    }
}


