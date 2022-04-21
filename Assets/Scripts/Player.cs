using System;
using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable, IKillable
{
    public Stats stats { get; set; }

    private void Start()
    {
        stats = GetComponent<Stats>();
    }

    public void Damage(int damagePoints)
    {
        stats.currentHealth -= damagePoints;
        Debug.Log("Oh noooo!: " + stats.currentHealth);
        if(stats.currentHealth <= 0)
        {
            Perish();
        }
    }

    public void Perish()
    {
        Debug.Log("Dead");
    }
}
