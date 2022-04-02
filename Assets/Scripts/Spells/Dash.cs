using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName = "Spells/Dash")]
public class Dash : Spell
{
    public float dashVelocity;

    public override void Activate(GameObject parent)
    {
        MovementController movementController = parent.GetComponent<MovementController>();
        Rigidbody rigidbody = parent.GetComponent<Rigidbody>();
        
        rigidbody.AddForce(movementController.transform.forward * dashVelocity * Time.deltaTime, ForceMode.VelocityChange);

    }
}
