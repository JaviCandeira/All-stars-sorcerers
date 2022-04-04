using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public float currentMana;

    public float MaxMana = 100f;

    public Slider manaBar;
    // Start is called before the first frame update
    public void Awake()
    {
        currentMana = MaxMana;
        manaBar.maxValue = MaxMana;
        manaBar.value = currentMana;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        manaBar.value = currentMana;
    }

    public void UseMana(float value)
    {
        currentMana -= value;
    }
    
}