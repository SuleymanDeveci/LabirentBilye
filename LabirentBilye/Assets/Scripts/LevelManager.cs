using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Button[] buttons1;
    [SerializeField] Button[] buttons2;
    int lastUnlockedLevel;
    int lastUnlockedLevel2;
    private void Awake()
    {
        lastUnlockedLevel = PlayerPrefs.GetInt("LastUnlockedLevel",1);
        lastUnlockedLevel2 = PlayerPrefs.GetInt("LastUnlockedLevel2",31);

        for (int i = 0; i < lastUnlockedLevel; i++) // burada lastunlockedLevel de�eri 2 oldu�unu d�s�nelim o zaman i de�eri maksimum 1 de�erini alabilecek for d�ng�s�n�n i�inde. buttons[1] butonuda
                                                    // zaten 2. levelin butonu
        {
            buttons1[i].interactable = true;  
        }
        
        for (int i = 0; i < (lastUnlockedLevel2 - 30); i++) // buradada ayn� i�lemi yetenek levelleri i�in tekrarl�yoruz
        {
            buttons2[i].interactable = true;  
        }
    }
}
