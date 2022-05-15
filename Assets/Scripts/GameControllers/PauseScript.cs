using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameControllers
{
    public class PauseScript : MonoBehaviour
    {
        public static bool IsPaused = false;
        public GameObject pauseMenu;
        public GameObject settingsMenu;
        public GameObject DeadUI;
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            if (IsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        public void PauseGame()
        {
            pauseMenu.SetActive(true);
            IsPaused = true;
            Time.timeScale = 0f;
        }

        public void ResumeGame()
        {
            pauseMenu.SetActive(false);
            IsPaused = false;
            Time.timeScale = 1f;
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void Settings()
        {
            Console.WriteLine("hello");
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }

        public void GoBack()
        {
            settingsMenu.SetActive(false);
            pauseMenu.SetActive(true);
            
        }
        public void RestartGame()
        {
            Destroy(PlayerManager.Instance.player);
            SceneManager.LoadScene("Level1");
            DeadUI.SetActive(false);
            Time.timeScale = 1f;
            ScoreCounter.Instance.score = 0;
            ScoreCounter.Instance.counttext.text = "Score : " + ScoreCounter.Instance.score.ToString();
        }
        
    }
}
