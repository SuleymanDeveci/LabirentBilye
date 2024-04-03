using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class TableMovementScript : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] Vector3 _torqueVector;
    Touch _touch;

    [SerializeField] TextMeshProUGUI _debugText1;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
        //_torqueVector = new Vector3(0,0,10f); inspectordan belirle

    }

    void Update()
    {
        
                // Bilgisayarda oynamak için kontrol kodlarý
        if (Input.GetKey("d"))
        {
            _rb.AddTorque(-_torqueVector * Time.deltaTime);
        }
        else if (Input.GetKey("a"))
        {
            _rb.AddTorque(_torqueVector * Time.deltaTime);
        }
        

        /*
        if(Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            _debugText1.text = _touch.position.ToString();
            

            if(_touch.position.x > Screen.width/2)
            {
                _rb.AddTorque(-_torqueVector * Time.deltaTime);
            }
            else
            {
                _rb.AddTorque(_torqueVector * Time.deltaTime);
            }
        }
        */

    }
}
