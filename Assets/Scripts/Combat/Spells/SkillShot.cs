using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu(fileName = "New Skillshot", menuName = "Spells/Skillshot")]
public class Skillshot : Spell
{
    public Rigidbody _vfx;
    public float skillShotForce = 200f;
    private SkillshotController skillshotController;

    public override void Activate(GameObject parent)
    {
        skillshotController = parent.GetComponent<SkillshotController>();
        skillshotController.skillShotForce = skillShotForce;
        skillshotController.projectile = _vfx;
        skillshotController.lifetime = lifeTime;

        skillshotController.Launch();
    }

}
