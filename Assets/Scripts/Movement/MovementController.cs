using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 7;
    public float dashSpeed = 1500;
    public bool _isDashing;


    private Vector3 moveDirection;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    public void Move(float horizontalInput, float verticalInput)
    {
        moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        if (moveDirection != Vector3.zero)
        {
            //To stop the object from rotating back to default position
            Quaternion moveRotation = Quaternion.LookRotation(moveDirection);
            moveRotation = Quaternion.RotateTowards(transform.rotation, moveRotation, 360 * Time.deltaTime * 2);
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            rb.MoveRotation(moveRotation);
        }
    }

    public void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        //Limits velocity if required
        //If faster than movement speed
        if(flatVel.magnitude > moveSpeed)
        {
            //Calculate max possible velocity and apply it
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    public void Dash()
    {
        rb.AddForce(transform.forward * dashSpeed * Time.deltaTime, ForceMode.Impulse);
        _isDashing = false;
    }
}
