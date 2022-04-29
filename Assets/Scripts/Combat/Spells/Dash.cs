using Movement;
using UnityEngine;

namespace Combat.Spells
{
    [CreateAssetMenu(fileName = "Dash", menuName = "Spells/Dash")]
    public class Dash : Spell
    {
        public float dashVelocity;

        public override void Activate(GameObject parent)
        {
            var animator = parent.GetComponent<Animator>();
            var movementController = parent.GetComponent<MovementController>();
            var rigidbody = parent.GetComponent<Rigidbody>();
            animator.Play("Dash");
            rigidbody.AddForce(movementController.transform.forward * dashVelocity * Time.deltaTime,
                ForceMode.VelocityChange);
        }
    }
}
