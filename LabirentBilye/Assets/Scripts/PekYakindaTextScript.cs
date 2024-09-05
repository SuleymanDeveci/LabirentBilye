using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PekYakindaTextScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI pekYakindaText;

    private void Start()
    {
        pekYakindaText.gameObject.SetActive(false);
    }

    public void ComingSoon()
    {
        pekYakindaText.gameObject.SetActive(true);

        StartCoroutine(ComingSoonCoroutine());
    }

    public IEnumerator ComingSoonCoroutine()
    {

        yield return new WaitForSeconds(1f);

        pekYakindaText.gameObject.SetActive(false);
    }
}
