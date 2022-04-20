using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float fullHealth = 100f;
    public float currentHealth;
    public Slider healthBar;
    public bool gameOver = false;
    private void Awake()
    {
        currentHealth = fullHealth;
        healthBar.maxValue = fullHealth;
        healthBar.value = currentHealth;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHealth;

        if (currentHealth <= 0 && gameOver == false)
        {
            gameOver = true;
            Destroy(gameObject,1.5f);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}