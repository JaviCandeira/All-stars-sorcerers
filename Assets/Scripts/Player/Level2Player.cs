using System;
using Enemies;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Animator))]
public class Level2Player : MonoBehaviour, IDamagable, IKillable
{
    
    public int maxMana;
    public Slider Slider;
    private int CurrentHealth { get; set; }

    private void Start()
    {
        
    }
    
    public void SetHealth(int health)
    {
        Slider.value = health;
    }

    private void OnEnable()
    {
        CurrentHealth = PlayerPrefs.GetInt("health");
        SetHealth(CurrentHealth);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("Health1",CurrentHealth);
    }

    public void Damage(int damagePoints)
    {
        CurrentHealth -= damagePoints;
        SetHealth(CurrentHealth);
        // Debug.Log("Oh noooo!: " + CurrentHealth);
        if(CurrentHealth <= 0)
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
