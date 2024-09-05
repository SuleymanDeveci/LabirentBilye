using System.Collections;
using UnityEngine;
public class TableMovementScript : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] Vector3 _torqueVector;
    Touch _touch;
    [SerializeField] GameObject gamePanel;  // canvastaki sað sol tuþlarýnýn falan bulunduðu oynanýþ paneli

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        //_torqueVector = new Vector3(0,0,10f); inspectordan belirle
        Time.timeScale = 1f;
        _rb.isKinematic = true;
        

        StartCoroutine(WaitForAnimation());

    }

    void Update()
    {
        
        
        if(Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if(_touch.position.x > Screen.width / 2)
            {
                RightRotate();
            }
            else if(_touch.position.x < Screen.width / 2)
            {
                LeftRotate();
            }
        }
        
                // Bilgisayarda oynamak için kontrol kodlarý

        /*
        if (Input.GetKey("d"))
        {
            //_rb.AddTorque(-_torqueVector * Time.deltaTime);
            RightRotate();
        }
        else if (Input.GetKey("a"))
        {

            //_rb.AddTorque(_torqueVector * Time.deltaTime);
            LeftRotate();
        }
        */
        

    }

   public void LeftRotate()
   {
       _rb.AddRelativeTorque(_torqueVector * Time.deltaTime);
   }

   public void RightRotate()
   {
       _rb.AddRelativeTorque(-_torqueVector * Time.deltaTime);
   } 

    private IEnumerator WaitForAnimation()  // bölüm basýndaki animasyon süresince masayý sabit tutmak için yazdýðým kod
    {
        yield return new WaitForSeconds(5.82f);
        _rb.isKinematic = false;
        gamePanel.SetActive(true); // animasyon bittikten sonra tuþlarýn olduðu panel açýlýyor

    }
}
