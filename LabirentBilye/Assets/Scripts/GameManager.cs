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


    //bu level yükleme sistemini Coroutine baþlatarak yapmamýzýn sebebi, sonraki seviyeyi yükle tuþuna bastýðýmýzda level yüklenene kadar anlýk ekrandaki görüntü donmasýn, diye
    // Coroutine methodlar çalýþtýktan sonra method bitene kadar metodun içinde kalmaz. ayný zamanda ana kodu ilerletmeye devam eder
    public void LoadLevelScene(int levelIndex = 0)
    {
        StartCoroutine(LoadLevelSceneAsync(levelIndex));
    }

    private IEnumerator LoadLevelSceneAsync(int levelIndex)
    { 
        yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex); // burada kod çaðrýlýrken 0 verilirse ayný leveli baþtan yükle 1 verilirse bir sonraki levele geç diye yazdýk    
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
