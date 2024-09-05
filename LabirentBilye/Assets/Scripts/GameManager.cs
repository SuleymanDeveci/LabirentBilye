using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace labirentBilye.Managers
{


    public class GameManager : MonoBehaviour
    {
        [SerializeField] AudioSource rollingSound;

        //public static GameManager Instance { get; private set; }


        private void Awake()
        {
            //SingletonThisGameObject();    // Singleton yaptýðýmýz zaman ilk sahnede sýkýntý yok ama sahneyi tekrar yüklediðimiz zaman veya farklý bir sahne yüklediðimiz zaman
                                            // bu gameManager objesini kullanan diðer scriptler gameManager objesini bulamýyor (Missing) hatasý veriyor. o yuzden bu þekilde yaptým.
        }

        private void Start()
        {
            Time.timeScale = 1f;
        }


        /*
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
        */

        //bu level yükleme sistemini Coroutine baþlatarak yapmamýzýn sebebi, sonraki seviyeyi yükle tuþuna bastýðýmýzda level yüklenene kadar anlýk ekrandaki görüntü donmasýn, diye
        // Coroutine methodlar çalýþtýktan sonra method bitene kadar metodun içinde kalmaz. ayný zamanda ana kodu ilerletmeye devam eder
        public void LoadNextSceneOrRestart(int levelIndex = 0)
        {
            StartCoroutine(LoadNextSceneOrRestartAsync(levelIndex));
        }

        private IEnumerator LoadNextSceneOrRestartAsync(int levelIndex)
        {
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex); // burada kod çaðrýlýrken 0 verilirse ayný leveli baþtan yükle 1 verilirse bir sonraki levele geç diye yazdýk    
        }

        public void LoadMenuScene()
        {
            StartCoroutine(LoadMenuSceneAsync());
        }

        private IEnumerator LoadMenuSceneAsync()
        {
            yield return SceneManager.LoadSceneAsync(0);
        }

        public void MenuStartButton()
        {
            StartCoroutine(LoadAnyLevelSceneAsync(PlayerPrefs.GetInt("LastUnlockedLevel2",31)));
        }

    
        public void LoadChosenLevel(int levelIndex)
        {
            StartCoroutine(LoadAnyLevelSceneAsync(levelIndex));
        }
        private IEnumerator LoadAnyLevelSceneAsync(int levelIndex)
        {
            yield return SceneManager.LoadSceneAsync(levelIndex); // burada kod çaðrýlýrken hangi sayý verilirse o level yüklenir. 0 verilirse main menü yüklenir.
        }
        


        public void UnlockNextLevel()
        {
            if(SceneManager.GetActiveScene().buildIndex < 31)
            {
                if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("LastUnlockedLevel", 1))
                {
                    PlayerPrefs.SetInt("LastUnlockedLevel", (PlayerPrefs.GetInt("LastUnlockedLevel", 1)) + 1);
                    LoadNextSceneOrRestart(1);
                }
                else
                {
                    LoadNextSceneOrRestart(1);
                }
            }
            else
            {
                if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("LastUnlockedLevel2", 31))
                {
                    PlayerPrefs.SetInt("LastUnlockedLevel2", (PlayerPrefs.GetInt("LastUnlockedLevel2", 31)) + 1);
                    LoadNextSceneOrRestart(1);
                }
                else
                {
                    LoadNextSceneOrRestart(1);
                }
            }

            
        }

        public void OnPaused()
        {
            Time.timeScale = 0f;
            rollingSound.Pause();
        }

        public void OnResumed()
        {
            Time.timeScale = 1f;
            rollingSound.Play();
        }

        public void AppQuit()
        {
            Application.Quit();
        }
    }

}
