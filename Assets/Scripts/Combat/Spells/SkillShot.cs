using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class SkillShot : MonoBehaviour
{
    public Transform skillShotSpawn;
    [HideInInspector] public float skillShotForce;
    [HideInInspector] public float lifetime;
    [HideInInspector] public Rigidbody projectile;
    private Quaternion lookRotation;
    
    public void Launch()
    {
        var clonedProjectile = Instantiate(projectile, skillShotSpawn.position + Vector3.up, transform.rotation);
        clonedProjectile.AddForce(skillShotSpawn.transform.forward * skillShotForce);
        Destroy(clonedProjectile.gameObject, lifetime);
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit))
        {
            lookRotation = Quaternion.LookRotation(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    
    }
    
}
