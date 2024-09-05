using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RestartPlayer : MonoBehaviour
{
    Rigidbody rb ,rbTable;
    GameObject startPositionObject;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rbTable = GameObject.FindGameObjectWithTag("Table").GetComponent<Rigidbody>();
        startPositionObject = GameObject.FindGameObjectWithTag("StartPositionObject");
    }

    public void Restart()
    {
        rb.transform.position = startPositionObject.transform.position;
        rb.velocity = Vector3.zero;
        Time.timeScale = 1f;
        rbTable.transform.rotation = new Quaternion(0,0,0,0);
        rbTable.angularVelocity = Vector3.zero; ;
        
    }
}
