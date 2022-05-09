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
        [SerializeField] private GameObject DeadUI;

        
        private void Start()
        {
        
            PlayerManager.Instance.CurrentMana = maxMana;
        //SetStats(maxHealth);
        }

        private void Update()
        {
            if (PlayerManager.Instance.CurrentMana < maxMana)
            {
                PlayerManager.Instance.CurrentMana += 1f * Time.deltaTime;
                PlayerManager.Instance.manaSlider.value = (float) PlayerManager.Instance.CurrentMana;
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
        public void depleteMana(double manaPoints)
        {
            PlayerManager.Instance.CurrentMana -= manaPoints;
            PlayerManager.Instance.manaSlider.value = (float) PlayerManager.Instance.CurrentMana;
        }
        public void ReplenishMana(double manaPoints)
        {
            PlayerManager.Instance.CurrentMana += manaPoints;
            PlayerManager.Instance.manaSlider.value = (float) PlayerManager.Instance.CurrentMana;
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

