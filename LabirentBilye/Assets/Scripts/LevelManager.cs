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

        for (int i = 0; i < lastUnlockedLevel; i++) // burada lastunlockedLevel deðeri 2 olduðunu düsünelim o zaman i deðeri maksimum 1 deðerini alabilecek for döngüsünün içinde. buttons[1] butonuda
                                                    // zaten 2. levelin butonu
        {
            buttons1[i].interactable = true;  
        }
        
        for (int i = 0; i < (lastUnlockedLevel2 - 30); i++) // buradada ayný iþlemi yetenek levelleri için tekrarlýyoruz
        {
            buttons2[i].interactable = true;  
        }
    }
}
