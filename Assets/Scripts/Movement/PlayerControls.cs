using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public bool _isPlayerTwo;
    private float _horizontalInput;
    private float _verticalInput;
    private MovementController _movement;
    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        SetInputs();
    }

    private void FixedUpdate()
    {
        _movement.Move(_horizontalInput, _verticalInput);
    }

    private void SetInputs()
    {
        if (!_isPlayerTwo)
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");
        }
        else
        {
            _horizontalInput = Input.GetAxis("Horizontal2");
            _verticalInput = Input.GetAxis("Vertical2");
        }
    }
}
