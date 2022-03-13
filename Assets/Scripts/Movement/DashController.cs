using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashController : MonoBehaviour
{
    [SerializeField] private float dashSpeed;
    private Rigidbody playerBody;
    private bool isDashing;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDashing = true;
            
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            Dash();
        }
    }

    private void Dash()
    {
        playerBody.AddForce(transform.forward * dashSpeed * Time.deltaTime, ForceMode.Impulse);
        isDashing = false;
    }
}
