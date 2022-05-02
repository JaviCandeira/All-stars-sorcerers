using Combat;
using Enemies;
using UnityEngine;
[RequireComponent(typeof(Animator))]
    public class Player : MonoBehaviour, IDamagable, IKillable
    {
        public int maxHealth;
        public int maxMana;

        private int CurrentHealth { get; set; }

        private void Start()
        {
        CurrentHealth = maxHealth;
        }

        public void Damage(int damagePoints)
        {
            CurrentHealth -= damagePoints;
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

