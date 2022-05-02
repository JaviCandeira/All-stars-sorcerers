using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float knockbackStrength =  1;
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Destroy(gameObject);
            rb.velocity = new Vector3();
            Vector3 direction = collision.transform.position - transform.position;
            direction.y = 0;
            rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
        }
    }
}


