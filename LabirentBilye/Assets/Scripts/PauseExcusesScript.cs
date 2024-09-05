using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseExcusesScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pauseExcuseText; 
    private string[] pauseExcuses = { "annen mi çaðýrýyor?","kulaðýna sinek mi kaçtý?","gözüne toz mu kaçtý?","kapý mý çalýyor?","parmaðýna kramp mý girdi?","odaya kuþ mu girdi?","týrnaðýn mý kýrýldý? (opsiyonel)",
        "telefon mu kasýyor?"};

    bool isFirstEnable = false;
    int lastExcuseIndex;
    int excuseIndex;


    public void SelectExcuse()
    {
        do
        {
            excuseIndex = UnityEngine.Random.Range(0, pauseExcuses.Length);
        }
        while (lastExcuseIndex == excuseIndex);

        if (isFirstEnable == false)
        {
            pauseExcuseText.text = ("Ne oldu " + pauseExcuses[excuseIndex] + " niye durduk");
            isFirstEnable=true;
            lastExcuseIndex = excuseIndex;
        }
        else
        {
            pauseExcuseText.text = ("Yine ne oldu " + pauseExcuses[excuseIndex] + " niye durduk");
            lastExcuseIndex=excuseIndex;
        }
        
    }

    public void OnEnable()
    {
        SelectExcuse();
    }
}