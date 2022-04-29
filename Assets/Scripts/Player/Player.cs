using Combat;
using Enemies;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour, IDamagable, IKillable
    {
        public Stats stats;

        private int CurrentHealth { get; set; }

        private void Start()
        {
            CurrentHealth = stats.maxHealth;
            PlayerManager.Instance.player = gameObject;
        }

        public void Damage(int damagePoints)
        {
            CurrentHealth -= damagePoints;
            Debug.Log("Oh noooo!: " + CurrentHealth);
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
}
