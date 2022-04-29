using UnityEngine;

namespace Movement
{
    public class PlayerControls : MonoBehaviour
    {
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
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");
        }
    }
}
