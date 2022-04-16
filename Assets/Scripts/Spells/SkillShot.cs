using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SkillShot : MonoBehaviour
{
    public Transform skillShotSpawn;
    [HideInInspector] public float skillShotForce;
    [HideInInspector] public float lifetime;
    [HideInInspector] public Rigidbody projectile;
    public void Launch()
    {
        var clonedProjectile = Instantiate(projectile, skillShotSpawn.position + Vector3.up, transform.rotation);
        clonedProjectile.AddForce(skillShotSpawn.transform.forward * skillShotForce);
        Destroy(clonedProjectile.gameObject, lifetime);
    }
}
