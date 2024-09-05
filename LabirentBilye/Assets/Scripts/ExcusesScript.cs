using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExcusesScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI excuseText; 
    private string[] excuses = { "Annem �a��rd�", "Kula��ma sinek ka�t�", "G�z�me toz ka�t�", "Kap� �ald�", "Parma��ma kramp girdi", "Odaya ku� girdi", "T�rna��m k�r�ld� (opsiyonel)", "Telefon kast�", "Tu� basmad�" };
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
        excuseText.text = "Bahane Y�kleniyor...";
        yield return new WaitForSeconds(1f);
        SelectExcuse();
    }
}