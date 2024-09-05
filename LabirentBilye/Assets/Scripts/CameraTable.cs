using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTable : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    private void Update()
    {
        transform.Rotate(0, rotationSpeed*Time.deltaTime, 0); // kamera ve masanýn dünya üzerinde yavaþça dönmesini saðlayan kod
    }
}
