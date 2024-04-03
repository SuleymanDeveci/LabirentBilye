using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExcusesScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI excuseText; 
    private string[] excuses = { "Annem �a��rd�","Kula��ma sinek ka�t�","G�z�me toz ka�t�","Kap� �ald�","baca��ma kramp girdi","odaya ku� girdi"};


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
        excuseText.text = "Bahane Y�kleniyor...";
        yield return new WaitForSeconds(1f);
        SelectExcuse();
    }
}