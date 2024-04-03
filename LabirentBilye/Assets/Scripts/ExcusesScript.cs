using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExcusesScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI excuseText; 
    private string[] excuses = { "Annem çaðýrdý","Kulaðýma sinek kaçtý","Gözüme toz kaçtý","Kapý çaldý","bacaðýma kramp girdi","odaya kuþ girdi"};


    public void SelectExcuse()
    {
        excuseText.text = excuses[UnityEngine.Random.Range(0, excuses.Length)];
    }

    public void OnEnable()
    {
        StartCoroutine(ExcuseCoolDown());
        
    }

    IEnumerator ExcuseCoolDown()
    {
        excuseText.text = "Bahane Yükleniyor...";
        yield return new WaitForSeconds(1f);
        SelectExcuse();
    }
}