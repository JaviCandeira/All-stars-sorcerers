using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion
    // public GameObject playerPrefab;
    public GameObject player;
    public int CurrentHealth = 100;
    public Slider Slider;
  
    

    
}


