using System;
using Combat;
using Enemies;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
    public class Player : MonoBehaviour, IDamagable, IKillable
    {
        public int maxHealth;
        public int maxMana;
        public Slider Slider;
        private int CurrentHealth { get; set; }

        private void Start()
        {
        CurrentHealth = maxHealth;
        SetMaxHealth(maxHealth);
        }
        public void SetMaxHealth(int health)
        {
            Slider.maxValue = health;
            Slider.value = health;
        }
        public void SetHealth(int health)
        {
            Slider.value = health;
        }

        private void OnDisable()
        {
            PlayerPrefs.SetInt("health",CurrentHealth);
        }

        public void Damage(int damagePoints)
        {
            CurrentHealth -= damagePoints;
            Slider.value = CurrentHealth;
            
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

