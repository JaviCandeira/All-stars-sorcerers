using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float knockbackStrength =  100000000;
    private void OnTriggerEnter(Collider collider)
    {
        var rb = collider.gameObject.GetComponent<Rigidbody>();
        
        Debug.Log(collider.gameObject.name);

        if (rb == null)
        {
            Debug.Log("Collider doesn't have a rigidbody");
        }
        var direction = collider.transform.position - transform.position;
        direction.y = 0;
        rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
        Destroy(gameObject);

    }
}


