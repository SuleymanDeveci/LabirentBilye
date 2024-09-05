using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExcusesScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI excuseText; 
    private string[] excuses = { "Annem çaðýrdý", "Kulaðýma sinek kaçtý", "Gözüme toz kaçtý", "Kapý çaldý", "Parmaðýma kramp girdi", "Odaya kuþ girdi", "Týrnaðým kýrýldý (opsiyonel)", "Telefon kastý", "Tuþ basmadý" };
    int lastExcuseIndex;
    int excuseIndex;

    public void SelectExcuse()
    {
        do
        {
            excuseIndex = UnityEngine.Random.Range(0, excuses.Length);
        }
        while (lastExcuseIndex == excuseIndex);

            excuseText.text = excuses[excuseIndex];
            lastExcuseIndex = excuseIndex;

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