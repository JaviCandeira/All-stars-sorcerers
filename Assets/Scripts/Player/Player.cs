using System;
using Combat;
using Enemies;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
    public class Player : MonoBehaviour, IDamagable, IKillable
    {
        
        public int maxMana;
        private int CurrentHealth { get; set; }
        public double CurrentMana { get;  private set; }
        [SerializeField] private GameObject DeadUI;

        
        private void Start()
        {
        
        CurrentMana = maxMana;
        //SetStats(maxHealth);
        }

        private void Update()
        {
            if (CurrentMana < maxMana)
            {
                CurrentMana += 1f * Time.deltaTime;
            }

            if (GetTransform().position.y < -15)
            {
                Perish();
            }
        }

        private void SetStats(int health)
        {
           // Slider.maxValue = health;
           // Slider.value = health;
        }
        public void SetHealth(int health)
        {
           // Slider.value = health;
        }

        
        public void Damage(int damagePoints)
        {
            PlayerManager.Instance.CurrentHealth -= damagePoints;
            PlayerManager.Instance.Slider.value = PlayerManager.Instance.CurrentHealth;
            
            if(PlayerManager.Instance.CurrentHealth <= 0)
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
            Destroy(this);
            Time.timeScale = 0f;
            DeadUI.SetActive(true);
            Debug.Log("Dead");
        }

    }

