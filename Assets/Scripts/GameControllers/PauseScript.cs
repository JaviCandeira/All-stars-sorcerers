using System;
using UnityEngine;

namespace GameControllers
{
    public class PauseScript : MonoBehaviour
    {
        public static bool IsPaused = false;
        public GameObject pauseMenu;
        public GameObject settingsMenu;
        
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
        
        
    }
}
