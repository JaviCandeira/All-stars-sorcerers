using System;
using Enemies;
using UnityEngine;

namespace Combat.Spells
{
    [RequireComponent(typeof(Collider))]
    public class DealDamage : MonoBehaviour
    {
        public int damagePoints = 1;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Enemy")) return;
            var enemy = other.gameObject.GetComponent<IDamagable>();
            if (other.gameObject.GetComponent<IDamagable>() == null) return;
            enemy.Damage(damagePoints);
            
        }
    }
}
