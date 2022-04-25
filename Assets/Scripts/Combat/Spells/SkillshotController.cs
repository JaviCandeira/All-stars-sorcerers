using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class SkillshotController : MonoBehaviour
{
    public Transform skillShotSpawn;
    [HideInInspector] public float skillShotForce;
    [HideInInspector] public float lifetime;
    [HideInInspector] public Rigidbody projectile;
    private Quaternion lookRotation;
    private Vector3 skillshotDirection;
    
    public void Launch()
    {
        var clonedProjectile = Instantiate(projectile, skillShotSpawn.position + Vector3.up, lookRotation);
        clonedProjectile.AddForce((skillshotDirection - skillShotSpawn.transform.position) * skillShotForce);
        Destroy(clonedProjectile.gameObject, lifetime);
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit))
        {
            skillshotDirection = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        }
    
    }
    
}
