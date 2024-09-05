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
            //SingletonThisGameObject();    // Singleton yapt���m�z zaman ilk sahnede s�k�nt� yok ama sahneyi tekrar y�kledi�imiz zaman veya farkl� bir sahne y�kledi�imiz zaman
                                            // bu gameManager objesini kullanan di�er scriptler gameManager objesini bulam�yor (Missing) hatas� veriyor. o yuzden bu �ekilde yapt�m.
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

        //bu level y�kleme sistemini Coroutine ba�latarak yapmam�z�n sebebi, sonraki seviyeyi y�kle tu�una bast���m�zda level y�klenene kadar anl�k ekrandaki g�r�nt� donmas�n, diye
        // Coroutine methodlar �al��t�ktan sonra method bitene kadar metodun i�inde kalmaz. ayn� zamanda ana kodu ilerletmeye devam eder
        public void LoadNextSceneOrRestart(int levelIndex = 0)
        {
            StartCoroutine(LoadNextSceneOrRestartAsync(levelIndex));
        }

        private IEnumerator LoadNextSceneOrRestartAsync(int levelIndex)
        {
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex); // burada kod �a�r�l�rken 0 verilirse ayn� leveli ba�tan y�kle 1 verilirse bir sonraki levele ge� diye yazd�k    
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
            yield return SceneManager.LoadSceneAsync(levelIndex); // burada kod �a�r�l�rken hangi say� verilirse o level y�klenir. 0 verilirse main men� y�klenir.
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
