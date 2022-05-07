using System;
using Combat;
using Enemies;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
    public class Player : MonoBehaviour, IDamagable, IKillable
    {
        
        public int maxMana;
        
        
        public void Damage(int damagePoints)
        {
            PlayerManager.Instance.CurrentHealth -= damagePoints;
            PlayerManager.Instance.Slider.value = PlayerManager.Instance.CurrentHealth;
            
            // Debug.Log("Oh noooo!: " + CurrentHealth);
            if(PlayerManager.Instance.CurrentHealth <= 0)
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

