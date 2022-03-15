using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController2 : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Send a ray to see if player is currently grounded
      
        SpeedControl();
        SetInputs();
    }

    private void FixedUpdate()
    {
        Move();
        
    }

    private void SetInputs()
    {
        horizontalInput = Input.GetAxis("Horizontal2");
        verticalInput = Input.GetAxis("Vertical2");
    }

    private void Move()
    {
        moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        //To stop the object from rotating back to default position
        if (moveDirection == Vector3.zero)
        {
            return;
        }
        Quaternion moveRotation = Quaternion.LookRotation(moveDirection);
        moveRotation = Quaternion.RotateTowards(transform.rotation, moveRotation, 360 * Time.deltaTime * 2 );
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        rb.MoveRotation(moveRotation);
    }

    private void SpeedControl()
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
}