using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseExcusesScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pauseExcuseText; 
    private string[] pauseExcuses = { "annen mi �a��r�yor?","kula��na sinek mi ka�t�?","g�z�ne toz mu ka�t�?","kap� m� �al�yor?","parma��na kramp m� girdi?","odaya ku� mu girdi?","t�rna��n m� k�r�ld�? (opsiyonel)",
        "telefon mu kas�yor?"};

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