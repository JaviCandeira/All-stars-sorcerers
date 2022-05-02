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
    private Quaternion _lookRotation;
    private Vector3 _skillshotDirection;
    
    public void Launch()
    {
        var clonedProjectile = Instantiate(projectile, skillShotSpawn.position + Vector3.up, _lookRotation);
        clonedProjectile.AddForce((_skillshotDirection - skillShotSpawn.transform.position).normalized * skillShotForce);
        Destroy(clonedProjectile.gameObject, lifetime);
    }

    private void Update()
    {
        if (Camera.main == null) return;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit)) return;
        var position = transform.position;
        _lookRotation = Quaternion.LookRotation(new Vector3(hit.point.x, position.y, hit.point.z));
        _skillshotDirection = new Vector3(hit.point.x, position.y, hit.point.z);
    }
    
}
