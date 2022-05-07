using System;
using Combat;
using Enemies;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
    public class Player : MonoBehaviour, IDamagable, IKillable
    {
        
        public int maxMana;
        public Slider Slider;
        private int CurrentHealth { get; set; }
        public double CurrentMana { get;  private set; }
        private void Start()
        {
        CurrentHealth = maxHealth;
        CurrentMana = maxMana;
        SetStats(maxHealth);
        }

        private void Update()
        {
            if (CurrentMana < maxMana)
            {
                CurrentMana += 1f * Time.deltaTime;
            }
        }

        private void SetStats(int health)
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
            PlayerManager.Instance.CurrentHealth -= damagePoints;
            PlayerManager.Instance.Slider.value = PlayerManager.Instance.CurrentHealth;
            
            if(CurrentHealth <= 0)
            {
                Perish();
            }
        }

        public void ReplenishMana(double manaPoints)
        {
            CurrentMana += manaPoints;
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

