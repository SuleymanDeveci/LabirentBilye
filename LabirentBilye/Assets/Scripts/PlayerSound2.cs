using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound2 : MonoBehaviour
{
    public AudioSource rollingSound;   // top yuvarlanma sesi
    public AudioSource hitingSound;   // top �arpma sesi
    public Rigidbody topRigidbody;    
    public float topRecPos3;         // topun h�z�n� �l�mek i�in topun �imdiki yerel pozisonu
    private float topRecPos4;         // topun h�z�n� �l�mek i�in topun 0.1 saniye �nceki yerel pozisyonu
    private float frameSpeed;         // benim belirledi�im s�re olan her 0.1f saniye aral���nda topun ne kadar mesafe katetti�ini �l��yor (topun h�z� da diyebiliriz)
    private bool ballHit;             // topun yeteri kadar h�zla biryere �arpt��� bilgisini tutuyor
    private bool ballTime;            // top biryere �arpt���nda arka arkaya �arpma sesi �almas�n diye 0.2 saniyelik bekleme s�resinin doldu�u bilgisini tutuyor
    private bool coroutineFlag;       // topun h�z�n� �l�t���m coroutine s�rekli arka arkaya �a�r�lmas�n diye kontrol eden bool


    private void Start()
    {
        ballHit = false;
        coroutineFlag = true;
        topRecPos3 = 0;
    }

    private void Update()
    {
        if (coroutineFlag == true)
        {
            coroutineFlag=false;
            StartCoroutine(SoundCoroutine());
        }
        

        rollingSound.volume = Mathf.Abs(topRecPos3) * 5;  // pozisyopn fark�n�n sesin volume de�i�kenine at�yoruz.     
        
        if ((frameSpeed < -0.15f) && ballHit == false)
        {
            hitingSound.volume = frameSpeed * -2f;
            hitingSound.Play();
            ballHit=true;
            StartCoroutine(SoundCoroutine2()); // bu corotune hit sesi ��kt�ktan sonra arka arkaya �almamas� i�in ballTime de�i�kenini 0.2 saniyelik gecikmeden sonra true yapar
        }


        if ((topRecPos3 > 0.1f) && ballHit == true && ballTime == true)
        {
            ballHit = false;
            ballTime = false;
        }


    }


    private IEnumerator SoundCoroutine()
    {
        Vector2 firstPos = new Vector2(topRigidbody.transform.localPosition.x, topRigidbody.transform.localPosition.y); // topun ilk yerel pozisyonunu al�yoruz
        yield return new WaitForSeconds(0.1f);
        Vector2 secondPos = new Vector2(topRigidbody.transform.localPosition.x, topRigidbody.transform.localPosition.y); // topun 2. yerel pozisyonunu al�yoruz
        topRecPos4 = topRecPos3;
        topRecPos3 = (secondPos - firstPos).magnitude;  // pozisyonlar�n fark�n� al�yoruz 
        frameSpeed = topRecPos3 - topRecPos4;
        coroutineFlag = true;
    }

    private IEnumerator SoundCoroutine2()  // top biryere �arpt���nda arka arkaya �arpma sesi �almas�n diye 0.2 saniyelik bekleme s�resi ekledim
    {
        yield return new WaitForSeconds(0.2f);
        ballTime = true;
    }
}
