using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        SingletonThisGameObject();
    }

    private void SingletonThisGameObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    //bu level y�kleme sistemini Coroutine ba�latarak yapmam�z�n sebebi, sonraki seviyeyi y�kle tu�una bast���m�zda level y�klenene kadar anl�k ekrandaki g�r�nt� donmas�n, diye
    // Coroutine methodlar �al��t�ktan sonra method bitene kadar metodun i�inde kalmaz. ayn� zamanda ana kodu ilerletmeye devam eder
    public void LoadLevelScene(int levelIndex = 0)
    {
        StartCoroutine(LoadLevelSceneAsync(levelIndex));
    }

    private IEnumerator LoadLevelSceneAsync(int levelIndex)
    { 
        yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex); // burada kod �a�r�l�rken 0 verilirse ayn� leveli ba�tan y�kle 1 verilirse bir sonraki levele ge� diye yazd�k    
    }

    public void LoadMenuScene()
    {
        StartCoroutine(LoadMenuSceneAsync());
    }

    private IEnumerator LoadMenuSceneAsync()
    {
        yield return SceneManager.LoadSceneAsync("Menu");
    }
}
