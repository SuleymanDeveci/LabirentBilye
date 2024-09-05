using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound2 : MonoBehaviour
{
    public AudioSource rollingSound;   // top yuvarlanma sesi
    public AudioSource hitingSound;   // top çarpma sesi
    public Rigidbody topRigidbody;    
    public float topRecPos3;         // topun hýzýný ölçmek için topun þimdiki yerel pozisonu
    private float topRecPos4;         // topun hýzýný ölçmek için topun 0.1 saniye önceki yerel pozisyonu
    private float frameSpeed;         // benim belirlediðim süre olan her 0.1f saniye aralýðýnda topun ne kadar mesafe katettiðini ölçüyor (topun hýzý da diyebiliriz)
    private bool ballHit;             // topun yeteri kadar hýzla biryere çarptýðý bilgisini tutuyor
    private bool ballTime;            // top biryere çarptýðýnda arka arkaya çarpma sesi çalmasýn diye 0.2 saniyelik bekleme süresinin dolduðu bilgisini tutuyor
    private bool coroutineFlag;       // topun hýzýný ölçtüðüm coroutine sürekli arka arkaya çaðrýlmasýn diye kontrol eden bool


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
        

        rollingSound.volume = Mathf.Abs(topRecPos3) * 5;  // pozisyopn farkýnýn sesin volume deðiþkenine atýyoruz.     
        
        if ((frameSpeed < -0.15f) && ballHit == false)
        {
            hitingSound.volume = frameSpeed * -2f;
            hitingSound.Play();
            ballHit=true;
            StartCoroutine(SoundCoroutine2()); // bu corotune hit sesi çýktýktan sonra arka arkaya çalmamasý için ballTime deðiþkenini 0.2 saniyelik gecikmeden sonra true yapar
        }


        if ((topRecPos3 > 0.1f) && ballHit == true && ballTime == true)
        {
            ballHit = false;
            ballTime = false;
        }


    }


    private IEnumerator SoundCoroutine()
    {
        Vector2 firstPos = new Vector2(topRigidbody.transform.localPosition.x, topRigidbody.transform.localPosition.y); // topun ilk yerel pozisyonunu alýyoruz
        yield return new WaitForSeconds(0.1f);
        Vector2 secondPos = new Vector2(topRigidbody.transform.localPosition.x, topRigidbody.transform.localPosition.y); // topun 2. yerel pozisyonunu alýyoruz
        topRecPos4 = topRecPos3;
        topRecPos3 = (secondPos - firstPos).magnitude;  // pozisyonlarýn farkýný alýyoruz 
        frameSpeed = topRecPos3 - topRecPos4;
        coroutineFlag = true;
    }

    private IEnumerator SoundCoroutine2()  // top biryere çarptýðýnda arka arkaya çarpma sesi çalmasýn diye 0.2 saniyelik bekleme süresi ekledim
    {
        yield return new WaitForSeconds(0.2f);
        ballTime = true;
    }
}
