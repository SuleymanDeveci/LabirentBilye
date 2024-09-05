using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsTriger : MonoBehaviour
{
    public Transform lastCheckPoint;
    public Transform startPosition;
    private Rigidbody rb;
    public Rigidbody rbTable;
    public AudioSource deadSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = lastCheckPoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spike")
        {
            deadSound.Play();

            rb.velocity = Vector3.zero;
            rb.transform.position = lastCheckPoint.position;

            rbTable.angularVelocity = Vector3.zero; ;
            rbTable.transform.rotation = new Quaternion(0, 0, 0, 0);
            
        }
        if (other.tag == "CheckPoint")
        {
            lastCheckPoint = other.transform;
        }
    }

    public void OnRestart()
    {
        lastCheckPoint = startPosition;
    }

    
}
