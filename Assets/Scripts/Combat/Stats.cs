using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "New Stats", menuName = "Stats")]
    public class Stats : ScriptableObject
    {
        public int maxHealth;

        public int maxMana;
    
        public int attackDamage;

        public int attackCooldown;
    
    }
}
