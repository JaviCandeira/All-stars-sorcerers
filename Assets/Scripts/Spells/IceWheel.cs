using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu(fileName = "IceWheel", menuName = "Spells/IceWheel")]
public class IceWheel : Spell
{
    public Rigidbody _vfx;
    public float skillShotForce = 200f;
    private SkillShot skillShot;

    public override void Activate(GameObject parent)
    {
        skillShot = parent.GetComponent<SkillShot>();
        skillShot.skillShotForce = skillShotForce;
        skillShot.projectile = _vfx;
        skillShot.lifetime = lifeTime;

        skillShot.Launch();
    }
}
