using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager Instance;
    public int CurrentHealth = 100;
    public Slider Slider;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
    }

    #endregion
    public GameObject player;

}


