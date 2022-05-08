using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager Instance;
    public int CurrentHealth = 100;
    public Slider Slider;
    [SerializeField] private GameObject DeadUI;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
    }

    #endregion
    public GameObject player;

    public void RestartGame()
    {
        Destroy(player);
        SceneManager.LoadScene("Level1");
        DeadUI.SetActive(false);
        Time.timeScale = 1f;
        ScoreCounter.Instance.score = 0;
        ScoreCounter.Instance.counttext.text = "Score : " + ScoreCounter.Instance.score.ToString();
    }
}


