using UnityEngine;

namespace Combat.Spells
{
    public class Spell : ScriptableObject
    {
        public new string name;
        public float cooldown;
        public float activeFor;
        public float manaCost;
        public float speed;
        public float lifeTime;

        public virtual void Activate(GameObject parent)
        {
        
        }
    }
}
