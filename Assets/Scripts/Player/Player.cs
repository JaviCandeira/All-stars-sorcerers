using System;
using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable, IKillable
{
    public Stats stats;

    public int currentHealth { get; set; }

    private void Start()
    {
        currentHealth = stats.maxHealth;
    }

    public void Damage(int damagePoints)
    {
        currentHealth -= damagePoints;
        Debug.Log("Oh noooo!: " + currentHealth);
        if(currentHealth <= 0)
        {
            Perish();
        }
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Perish()
    {
        Debug.Log("Dead");
    }
}
