using UnityEngine;

namespace Combat.Spells
{
    [CreateAssetMenu(fileName = "New Skillshot", menuName = "Spells/Skillshot")]
    public class Skillshot : Spell
    {
        public Rigidbody vfx;
        public float skillShotForce = 200f;
        private SkillshotController _skillshotController;

        public override void Activate(GameObject parent)
        {
            _skillshotController = parent.GetComponent<SkillshotController>();
            _skillshotController.skillShotForce = skillShotForce;
            _skillshotController.projectile = vfx;
            _skillshotController.lifetime = lifeTime;

            _skillshotController.Launch();
        }

    }
}
